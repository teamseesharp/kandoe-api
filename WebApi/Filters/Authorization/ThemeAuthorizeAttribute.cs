using System;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

using Kandoe.Business;
using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;

namespace Kandoe.Web.Filters.Authorization {
    public class ThemeAuthorizeAttribute :  ActionFilterAttribute {
        private readonly IService<Account> accounts;
        private readonly IService<Organisation> organisations;

        public ThemeAuthorizeAttribute() {
            this.accounts = new AccountService();
            this.organisations = new OrganisationService();
        }

        public override void OnActionExecuting(HttpActionContext actionContext) {
            ThemeDto dto = (ThemeDto) actionContext.ActionArguments["dto"];

            Organisation organisation = this.organisations.Get(dto.OrganisationId);

            string secret = Thread.CurrentPrincipal.Identity.Name;
            Account organiser = this.accounts.Get(organisation.OrganiserId);

            // in case the theme organiserId does not correspond with issuer id
            if (dto.OrganiserId != organiser.Id) {
                throw new ArgumentException();
            }

            // in case the issuer is not the organiser of the theme's
            if (organiser.Secret != secret) {
                throw new UnauthorizedAccessException();
            }

            base.OnActionExecuting(actionContext);
        }

    }
}