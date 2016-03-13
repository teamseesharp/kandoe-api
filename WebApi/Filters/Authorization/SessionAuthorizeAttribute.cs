using System;
using System.Linq;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Kandoe.Business;
using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;

namespace Kandoe.Web.Filters.Authorization {
    public class SessionAuthorizeAttribute : ActionFilterAttribute {
        private readonly IService<Account> accounts;
        private readonly IService<Session> sessions;
        private readonly IService<Subtheme> subthemes;

        public SessionAuthorizeAttribute() {

            this.accounts = new AccountService();
            this.sessions = new SessionService();
            this.subthemes = new SubthemeService();
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

        private void AuthorizePost(HttpActionContext actionContext) {
            SessionDto dto = (SessionDto) actionContext.ActionArguments["dto"];

            Subtheme subtheme = this.subthemes.Get(dto.SubthemeId);

            string secret = Thread.CurrentPrincipal.Identity.Name;
            Account organiser = this.accounts.Get(subtheme.OrganiserId);

            // in case the issuer is not the organiser of the subtheme
            if (organiser.Secret != secret) {
                throw new UnauthorizedAccessException();
            }
        }

        private void AuthorizePut(HttpActionContext actionContext) {
            SessionDto dto = (SessionDto) actionContext.ActionArguments["dto"];

            Session session = this.sessions.Get(dto.Id, collections: true);

            string secret = Thread.CurrentPrincipal.Identity.Name;
            Account issuer = this.accounts.Get(a => a.Secret == secret).First();

            // unauthorized in case the issuer is not an organiser of the session
            if (!session.Organisers.Contains(issuer)) {
                throw new UnauthorizedAccessException();
            }
        }
    }
}