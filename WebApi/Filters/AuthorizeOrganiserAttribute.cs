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
        public AuthorizeOrganiserAttribute() {
            this.Accounts = new AccountService();
            this.Organisations = new OrganisationService();
            this.Sessions = new SessionService();
            this.Subthemes = new SubthemeService();
            this.Themes = new ThemeService();
        }

        public IService<Account> Accounts { get; set; }
        public IService<Organisation> Organisations { get; set; }
        public IService<Session> Sessions { get; set; }
        public IService<Subtheme> Subthemes { get; set; }
        public IService<Theme> Themes { get; set; }

        public override void OnActionExecuting(HttpActionContext actionContext) {
            switch (actionContext.Request.Method.Method) {
                case "POST":
                    this.AuthorizePost(actionContext);
                    break;
                case "PUT":
                    this.AuthorizePut(actionContext);
                    break;
                default:
                    this.Unauthorize();
                    break;
            }

            base.OnActionExecuting(actionContext);
        }

        public void AuthorizeOrganiser(int organiserId) {
            // issuer secret
            string secret = Thread.CurrentPrincipal.Identity.Name;
            // organiser secret
            Account organiser = this.Accounts.Get(organiserId);

            // if account does not exist
            if (organiser == null) {
                this.Unauthorize();
            }

            // unauthorized action if issuer != organiser
            if (organiser.Secret != secret) {
                this.Unauthorize();
            }
        }

        public void AuthorizeOrganiser(ICollection<Account> organisers) {
            // issuer secret
            string secret = Thread.CurrentPrincipal.Identity.Name;
            // organiser secret
            Account organiser = this.Accounts.Get(a => a.Secret == secret).FirstOrDefault();

            // if account does not exist or there are no organisers
            if (organiser == null || organisers == null) {
                this.Unauthorize();
            }

            // unauthorized action if issuer != organiser
            if (!organisers.Contains(organiser)) {
                this.Unauthorize();
            }
        }

        private void AuthorizePost(HttpActionContext actionContext) {
            int organiserId;

            string controller = actionContext.ControllerContext.ControllerDescriptor.ControllerName;

            switch (controller) {
                case "Subtheme":
                    SubthemeDto subthemeDto = (SubthemeDto) actionContext.ActionArguments["dto"];
                    Theme theme = this.Themes.Get(subthemeDto.ThemeId);
                    organiserId = theme.OrganiserId;
                    break;
                case "Theme":
                    ThemeDto themeDto = (ThemeDto) actionContext.ActionArguments["dto"];
                    Organisation organisation = this.Organisations.Get(themeDto.OrganisationId);
                    organiserId = organisation.OrganiserId;
                    break;
                case "Session":
                    SessionDto sessionDto = (SessionDto) actionContext.ActionArguments["dto"];
                    Subtheme subtheme = this.Subthemes.Get(sessionDto.SubthemeId);
                    organiserId = subtheme.OrganiserId;
                    break;
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
                    Organisation organisation = this.Organisations.Get(organisationDto.Id);
                    organiserId = organisation.OrganiserId;
                    break;
                case "Subtheme":
                    SubthemeDto subthemeDto = (SubthemeDto) actionContext.ActionArguments["dto"];
                    Subtheme subtheme = this.Subthemes.Get(subthemeDto.Id);
                    organiserId = subtheme.OrganiserId;
                    break;
                case "Theme":
                    ThemeDto themeDto = (ThemeDto) actionContext.ActionArguments["dto"];
                    Theme theme = this.Themes.Get(themeDto.Id);
                    organiserId = themeDto.OrganiserId;
                    break;
                case "Session":
                    SessionDto sessionDto = (SessionDto) actionContext.ActionArguments["dto"];
                    Session session = this.Sessions.Get(sessionDto.Id, collections: true);

                    this.AuthorizeOrganiser(session.Organisers);
                    
                    return;
                default:    // will be unauthorized
                    organiserId = -1;
                    break;
            }

            this.AuthorizeOrganiser(organiserId);
        }

        public void Unauthorize() {
            throw new UnauthorizedAccessException();
        }
    }
}