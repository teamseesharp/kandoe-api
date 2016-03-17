using System;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

using Kandoe.Business;
using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;

namespace Kandoe.Web.Filters.Authorization {
    public class AuthorizeSubthemeOrganiserAttribute : ActionFilterAttribute {
        private readonly IService<Account> accounts;
        private readonly IService<Theme> theme;

        public AuthorizeSubthemeOrganiserAttribute() {
            this.accounts = new AccountService();
            this.theme = new ThemeService();
        }

        public override void OnActionExecuting(HttpActionContext actionContext) {
            SubthemeDto dto = (SubthemeDto) actionContext.ActionArguments["dto"];

            Theme theme = this.theme.Get(dto.ThemeId);

            string secret = Thread.CurrentPrincipal.Identity.Name;
            //current
            Account organiser = this.accounts.Get(theme.OrganiserId);

            // in case the subtheme organiserId does not correspond with organiser id
            if (dto.OrganiserId != organiser.Id) {
                throw new ArgumentException();
            }

            // in case the issuer is not the organiser of the subtheme
            if (organiser.Secret != secret) {
                throw new UnauthorizedAccessException();
            }

            base.OnActionExecuting(actionContext);
        }
    }
}