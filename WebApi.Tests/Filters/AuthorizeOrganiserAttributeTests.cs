using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web.Http.Controllers;

using Moq;
using NUnit.Framework;

using Kandoe.Business;
using Kandoe.Business.Domain;
using Kandoe.Business.Tests.Fakes;

using Kandoe.Web.Filters;
using Kandoe.Web.Model.Dto;

namespace Kandoe.Web.Tests.Filters.Authorization {
    [TestFixture]
    public class AuthorizeOrganiserAttributeTest {
        private Mock<IIdentity> identity;
        private Mock<IPrincipal> principal;

        private IService<Account> accounts;
        private IService<Organisation> organisations;
        private IService<Session> sessions;
        private IService<Subtheme> subthemes;
        private IService<Theme> themes;

        private string unauthorized;
        private string authorized;

        private HttpActionContext context;
        private AuthorizeOrganiserAttribute filter;

        public static IEnumerable AuthorizationCases {
            get {
                yield return new TestCaseData("PATCH", "Session", null);
                yield return new TestCaseData("POST", "Session",
                    new SessionDto {
                        CardCreationAllowed = true, CurrentPlayerIndex = 0, Description = "descr",
                        IsFinished = false, MaxCardsToChoose = 10, MaxParticipants = 10, Round = 1,
                        SubthemeId = 1, Start = DateTime.Now, End = DateTime.Now.AddDays(6)
                    });

                yield return new TestCaseData("POST", "Theme", new ThemeDto { Name = "name", Description = "descr", OrganisationId = 1, OrganiserId = 1, Tags = "tags" });

                yield return new TestCaseData("PUT", "Organisation", new OrganisationDto { Id = 1, Name = "changedname", OrganiserId = 1 });
                yield return new TestCaseData("PUT", "Session",
                    new SessionDto {
                        Id = 1, CardCreationAllowed = true, CurrentPlayerIndex = 0, Description = "changeddescr",
                        IsFinished = false, MaxCardsToChoose = 10, MaxParticipants = 10, Round = 1,
                        SubthemeId = 1, Start = DateTime.Now, End = DateTime.Now.AddDays(6)
                    });
                yield return new TestCaseData("PUT", "Subtheme", new SubthemeDto { Id = 1, Name = "changedname", OrganiserId = 1, ThemeId = 1 });
                yield return new TestCaseData("PUT", "Theme", new ThemeDto { Id = 1, Name = "changedname", Description = "descr", OrganisationId = 1, OrganiserId = 1, Tags = "tags" });
            }
        }

        public static IEnumerable UnauthenticatedCases {
            get {
                yield return new TestCaseData("POST");
                yield return new TestCaseData("PUT");
            }
        }

        [OneTimeSetUp]
        public void OneTimeSetUp() {
            this.accounts = FakeServiceFactory.Create<Account>();
            this.organisations = FakeServiceFactory.Create<Organisation>();
            this.sessions = FakeServiceFactory.Create<Session>();
            this.subthemes = FakeServiceFactory.Create<Subtheme>();
            this.themes = FakeServiceFactory.Create<Theme>();

            this.unauthorized = "unauthorizedusersecret";
            this.authorized = "authorizedusersecret";

            Account account1 = new Account("mail1@mail.com", "name1", "surname1", "picture1", this.authorized) {
                Organisations = new List<Organisation>(),
                OrganisedSessions = new List<Session>(),
                Subthemes = new List<Subtheme>(),
                Themes = new List<Theme>()
            };
            account1 = this.accounts.Add(account1);
            Account account2 = new Account("mail2@mail.com", "name2", "surname2", "picture2", this.unauthorized);
            account2 = this.accounts.Add(account2);

            Organisation organisation = new Organisation("name", account1.Id) {
                Sessions = new List<Session>(),
                Themes = new List<Theme>()
            };
            organisation = this.organisations.Add(organisation);
            account1.Organisations.Add(organisation);
            this.accounts.Change(account1);

            Theme theme = new Theme("name", "descr", organisation.Id, organisation.OrganiserId, "tag") {
                Subthemes = new List<Subtheme>()
            };
            theme = this.themes.Add(theme);
            organisation.Themes.Add(theme);
            this.organisations.Change(organisation);
            account1.Themes.Add(theme);
            this.accounts.Change(account1);

            Subtheme subtheme = new Subtheme("name", theme.OrganiserId, theme.Id) {
                Sessions = new List<Session>()
            };
            subtheme = this.subthemes.Add(subtheme);
            theme.Subthemes.Add(subtheme);
            this.themes.Change(theme);
            account1.Subthemes.Add(subtheme);
            this.accounts.Change(account1);

            Session session = new Session(true, 0, "descr", false, 10, 10, organisation.Id, 0, subtheme.Id, DateTime.Now, DateTime.Now.AddDays(5)) {
                Organisers = new List<Account>()
            };
            session = this.sessions.Add(session);
            subtheme.Sessions.Add(session);
            this.subthemes.Change(subtheme);
            account1.OrganisedSessions.Add(session);
            session.Organisers.Add(account1);
            this.accounts.Change(account1);
            this.sessions.Change(session);
        }

        [SetUp]
        public void SetUp() {
            this.identity = new Mock<IIdentity>();
            this.principal = new Mock<IPrincipal>();

            this.context = Utilities.CreateActionContext();

            this.filter = new AuthorizeOrganiserAttribute() {
                Accounts = this.accounts,
                Organisations = this.organisations,
                Sessions = this.sessions,
                Subthemes = this.subthemes,
                Themes = this.themes
            };
        }

        [Test, TestCaseSource("AuthorizationCases")]
        public void OrganiserShouldBeAuthorized(string method, string controller, object dto) {
            this.identity.SetupGet(i => i.Name).Returns(this.authorized);
            this.principal.SetupGet(p => p.Identity).Returns(this.identity.Object);
            Thread.CurrentPrincipal = this.principal.Object;

            HttpMethod httpMethod = new HttpMethod(method);
            this.context.Request.Method = httpMethod;
            this.context.RequestContext.RouteData.Values["id"] = "1";
            this.context.ControllerContext.ControllerDescriptor.ControllerName = controller;

            this.context.ActionArguments["dto"] = dto;

            Assert.DoesNotThrow(() => this.filter.OnActionExecuting(this.context));
        }

        [Test, TestCaseSource("AuthorizationCases")]
        public void NonOrganiserShouldNotBeAuthorized(string method, string controller, object dto) {
            this.identity.SetupGet(i => i.Name).Returns(this.unauthorized);
            this.principal.SetupGet(p => p.Identity).Returns(this.identity.Object);
            Thread.CurrentPrincipal = this.principal.Object;

            HttpMethod httpMethod = new HttpMethod(method);
            this.context.Request.Method = httpMethod;
            this.context.RequestContext.RouteData.Values["id"] = "1";
            this.context.ControllerContext.ControllerDescriptor.ControllerName = controller;

            this.context.ActionArguments["dto"] = dto;
            Assert.Throws<UnauthorizedAccessException>(() => this.filter.OnActionExecuting(this.context));
        }

        [Test]
        public void ShouldUnauthorize() {
            Assert.Throws<UnauthorizedAccessException>(() => this.filter.Unauthorize());
        }

        [Test, TestCaseSource("UnauthenticatedCases")]
        public void UnauthenticatedOrganiserShouldNotBeAuthorized(string method) {
            this.principal.SetupGet(p => p.Identity).Returns(this.identity.Object);
            Thread.CurrentPrincipal = this.principal.Object;

            Assert.Throws<UnauthorizedAccessException>(() => this.filter.AuthorizeOrganiser(2));

            ICollection<Account> nonOrganisers = new List<Account>();
            nonOrganisers.Add(this.accounts.Get(2));
            Assert.Throws<UnauthorizedAccessException>(() => this.filter.AuthorizeOrganiser(nonOrganisers));
        }
    }
}
