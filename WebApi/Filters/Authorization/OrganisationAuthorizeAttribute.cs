using System;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

using Kandoe.Business;
using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;

namespace Kandoe.Web.Filters.Authorization {
    public class OrganisationAuthorizeAttribute :  ActionFilterAttribute {
        private readonly IService<Account> accounts;

        public OrganisationAuthorizeAttribute() {
            this.accounts = new AccountService();
        }

        public override void OnActionExecuting(HttpActionContext actionContext) {
            OrganisationDto dto = (OrganisationDto) actionContext.ActionArguments["dto"];

            string secret = Thread.CurrentPrincipal.Identity.Name;
            Account issuer = this.accounts.Get(dto.OrganiserId);

            if (issuer.Secret != secret) {
                throw new UnauthorizedAccessException();
            }

            base.OnActionExecuting(actionContext);
        }
    }
}