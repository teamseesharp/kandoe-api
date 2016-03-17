using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Kandoe.Business;
using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;

namespace Kandoe.Web.Filters.Authorization {
    public class SnapshotAuthorizeAttribute : ActionFilterAttribute {
        private readonly IService<Account> accounts;
        private readonly IService<Session> sessions;

        public SnapshotAuthorizeAttribute() {
            this.accounts = new AccountService();
            this.sessions = new SessionService();
        }

        public override void OnActionExecuting(HttpActionContext actionContext) {
            SnapshotDto dto = (SnapshotDto) actionContext.ActionArguments["dto"];
            Session session = this.sessions.Get(dto.SessionId, collections: true);

            string secret = Thread.CurrentPrincipal.Identity.Name;
            Account issuer = this.accounts.Get(a => a.Secret == secret).First();

            // unauthorized in case the issuer is not an organiser of the session
            if (!dto.Organisers.Contains(issuer.Id)) {
                throw new UnauthorizedAccessException();
            }

            base.OnActionExecuting(actionContext);
        }
    }
}