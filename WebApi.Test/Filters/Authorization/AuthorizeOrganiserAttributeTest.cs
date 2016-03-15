using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;

using Moq;
using NUnit.Framework;

using Kandoe.Web.Auth0;
using Kandoe.Web.Filters.Authorization;
using Kandoe.Web.Model.Dto;

namespace WebApi.Tests.Filters.Authorization {
    [TestFixture]
    public class AuthorizeOrganiserAttributeTest {
        private Mock<IIdentity> identity;
        private Mock<IPrincipal> principal;

        private string unauthorized;
        private string authorized;

        private HttpActionContext context;

        [OneTimeSetUp]
        public void TestFixtureSetUp() {
            // cas acc, Id == 4
            this.unauthorized = "auth0|56d49e6d6568e621399e379c";
            // thomas acc, Id == 1
            this.authorized = "auth0|56d4591317aca91f1aff5dfb";
        }

        [SetUp]
        public void SetUp() {
            this.identity = new Mock<IIdentity>();
            this.principal = new Mock<IPrincipal>();

            this.context = Utilities.CreateActionContext();
        }

        [Test]
        public void OrganiserShouldBeAuthorized() {
            this.identity.SetupGet(i => i.Name).Returns(this.authorized);
            this.principal.SetupGet(p => p.Identity).Returns(this.identity.Object);
            Thread.CurrentPrincipal = this.principal.Object;

            this.context.ActionArguments["dto"] = new OrganisationDto() {
                Id = 1,
                OrganiserId = 1
            };

            AuthorizeOrganiserAttribute filter = new AuthorizeOrganiserAttribute();

            Assert.DoesNotThrow(() => filter.OnActionExecuting(this.context));
        }

        [Test]
        public void NonOrganiserShouldNotBeAuthorized() {
            this.identity.SetupGet(i => i.Name).Returns(this.unauthorized);
            this.principal.SetupGet(p => p.Identity).Returns(this.identity.Object);
            Thread.CurrentPrincipal = this.principal.Object;

            this.context.ActionArguments["dto"] = new OrganisationDto() {
                Id = 1,
                OrganiserId = 1
            };

            AuthorizeOrganiserAttribute filter = new AuthorizeOrganiserAttribute();

            Assert.Throws<UnauthorizedAccessException>(() => filter.OnActionExecuting(this.context));
        }

        [Test]
        public void UnauthenticatedOrganiserShouldNotBeAuthorized() {
            this.context.ActionArguments["dto"] = new OrganisationDto() {
                Id = 1,
                OrganiserId = 1
            };

            AuthorizeOrganiserAttribute filter = new AuthorizeOrganiserAttribute();

            Assert.Throws<UnauthorizedAccessException>(() => filter.OnActionExecuting(this.context));
        }
    }
}
