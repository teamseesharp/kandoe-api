using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

using Kandoe.Business;
using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;

namespace Kandoe.Web.Filters {
    public class AuthorizeOrganiserAttribute :  ActionFilterAttribute {
        private readonly IService<Account> accounts;
        private readonly IService<Organisation> organisations;
        private readonly IService<Session> sessions;
        private readonly IService<Subtheme> subthemes;
        private readonly IService<Theme> themes;

        public AuthorizeOrganiserAttribute() {
            this.accounts = new AccountService();
            this.organisations = new OrganisationService();
            this.sessions = new SessionService();
            this.subthemes = new SubthemeService();
            this.themes = new ThemeService();
        }

        public override void OnActionExecuting(HttpActionContext actionContext) {
            switch (actionContext.Request.Method.Method) {
                case "POST":
                    this.AuthorizePost(actionContext);
                    break;
                case "PUT":
                    this.AuthorizePut(actionContext);
                    break;
                default:
                    break;
            }

            base.OnActionExecuting(actionContext);
        }

        private void AuthorizeOrganiser(int organiserId) {
            // issuer secret
            string secret = Thread.CurrentPrincipal.Identity.Name;
            // organiser secret
            Account organiser = this.accounts.Get(organiserId);

            // if account does not exist
            if (organiser == null) {
                throw new UnauthorizedAccessException();
            }

            // unauthorized action if issuer != organiser
            if (organiser.Secret != secret) {
                throw new UnauthorizedAccessException();
            }
        }

        private void AuthorizeOrganiser(ICollection<Account> organisers) {
            // issuer secret
            string secret = Thread.CurrentPrincipal.Identity.Name;
            // organiser secret
            Account organiser = this.accounts.Get(a => a.Secret == secret).First();

            // if account does not exist or there are no organisers
            if (organiser == null || organisers == null) {
                throw new UnauthorizedAccessException();
            }

            // unauthorized action if issuer != organiser
            if (!organisers.Contains(organiser)) {
                throw new UnauthorizedAccessException();
            }
        }

        private void AuthorizePost(HttpActionContext actionContext) {
            int organiserId;

            string controller = actionContext.ControllerContext.ControllerDescriptor.ControllerName;

            switch (controller) {
                case "Subtheme":
                    SubthemeDto subthemeDto = (SubthemeDto) actionContext.ActionArguments["dto"];
                    Theme theme = this.themes.Get(subthemeDto.ThemeId);
                    organiserId = theme.OrganiserId;
                    break;
                case "Theme":
                    ThemeDto themeDto = (ThemeDto) actionContext.ActionArguments["dto"];
                    Organisation organisation = this.organisations.Get(themeDto.OrganisationId);
                    organiserId = organisation.OrganiserId;
                    break;
                case "Session":
                    SessionDto sessionDto = (SessionDto) actionContext.ActionArguments["dto"];
                    Subtheme subtheme = this.subthemes.Get(sessionDto.SubthemeId);
                    organiserId = subtheme.OrganiserId;
                    break;
                case "Snapshot":
                    SnapshotDto snapshotDto = (SnapshotDto) actionContext.ActionArguments["dto"];
                    Session session = this.sessions.Get(snapshotDto.SessionId, collections: true);
                    this.AuthorizeOrganiser(session.Organisers);
                    return;
                default:    // to prevent the dto from being null
                    organiserId = -1;
                    break;
            }

            this.AuthorizeOrganiser(organiserId);
        }

        private void AuthorizePut(HttpActionContext actionContext) {
            int organiserId;

            string controller = actionContext.ControllerContext.ControllerDescriptor.ControllerName;

            switch (controller) {
                case "Organisation":
                    OrganisationDto organisationDto = (OrganisationDto) actionContext.ActionArguments["dto"];
                    Organisation organisation = this.organisations.Get(organisationDto.Id);
                    organiserId = organisation.OrganiserId;
                    break;
                case "Subtheme":
                    SubthemeDto subthemeDto = (SubthemeDto) actionContext.ActionArguments["dto"];
                    Subtheme subtheme = this.subthemes.Get(subthemeDto.Id);
                    organiserId = subtheme.OrganiserId;
                    break;
                case "Theme":
                    ThemeDto themeDto = (ThemeDto) actionContext.ActionArguments["dto"];
                    Theme theme = this.themes.Get(themeDto.Id);
                    organiserId = themeDto.OrganiserId;
                    break;
                case "Session":
                    SessionDto sessionDto = (SessionDto) actionContext.ActionArguments["dto"];
                    Session session = this.sessions.Get(sessionDto.Id, collections: true);

                    this.AuthorizeOrganiser(session.Organisers);
                    
                    return;
                default:    // will be unauthorized
                    organiserId = -1;
                    break;
            }

            this.AuthorizeOrganiser(organiserId);
        }
    }
}