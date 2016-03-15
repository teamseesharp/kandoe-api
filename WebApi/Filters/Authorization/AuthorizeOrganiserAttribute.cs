using System;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

using Kandoe.Business;
using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;

namespace Kandoe.Web.Filters.Authorization {
    public class AuthorizeOrganiserAttribute :  ActionFilterAttribute {
        private readonly IService<Account> accounts;

        public AuthorizeOrganiserAttribute() {
            this.accounts = new AccountService();
        }

        public override void OnActionExecuting(HttpActionContext actionContext) {
            OrganisationDto dto = (OrganisationDto) actionContext.ActionArguments["dto"];

            // issuer secret
            string secret = Thread.CurrentPrincipal.Identity.Name;
            // organiser secret
            Account organiser = this.accounts.Get(dto.OrganiserId);

            // unauthorized action if issuer != organiser
            if (organiser.Secret != secret) {
                throw new UnauthorizedAccessException();
            }

            base.OnActionExecuting(actionContext);
        }
    }
}