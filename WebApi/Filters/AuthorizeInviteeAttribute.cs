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
    public class AuthorizeInviteeAttribute : ActionFilterAttribute {
        public AuthorizeInviteeAttribute() {
            this.Accounts = new AccountService();
            this.Sessions = new SessionService();
        }

        public IService<Account> Accounts { get; set; }
        public IService<Session> Sessions { get; set; }

        public override void OnActionExecuting(HttpActionContext actionContext) {
            switch (actionContext.Request.Method.Method) {
                case "PATCH":
                    this.AuthorizePatch(actionContext);
                    break;
                default:
                    this.Unauthorize();
                    break;
            }

            base.OnActionExecuting(actionContext);
        }

        public void AuthorizeInvitee(int inviteeId) {
            // issuer secret
            string secret = Thread.CurrentPrincipal.Identity.Name;
            // invitee secret
            Account invitee = this.Accounts.Get(inviteeId);

            // if account does not exist
            if (invitee == null) {
                this.Unauthorize();
            }

            // unauthorized action if issuer != invitee
            if (invitee.Secret != secret) {
                this.Unauthorize();
            }
        }

        public void AuthorizeInvitee(ICollection<Account> invitees) {
            // issuer secret
            string secret = Thread.CurrentPrincipal.Identity.Name;
            // invitee secret
            Account invitee = this.Accounts.Get(a => a.Secret == secret).FirstOrDefault();

            // if account does not exist or there are no invitees
            if (invitee == null || invitees == null) {
                this.Unauthorize();
            }

            // unauthorized action if issuer != invitee
            if (!invitees.Contains(invitee)) {
                this.Unauthorize();
            }
        }

        private void AuthorizePatch(HttpActionContext actionContext) {
            int inviteeId;

            string controller = actionContext.ControllerContext.ControllerDescriptor.ControllerName;

            switch (controller) {
                case "Session":
                    int id = (int) actionContext.RequestContext.RouteData.Values["id"];
                    Session session = this.Sessions.Get(id, collections: true);

                    this.AuthorizeInvitee(session.Invitees);

                    return;
                default:    // will be unauthorized
                    inviteeId = -1;
                    break;
            }

            this.AuthorizeInvitee(inviteeId);
        }

        public void Unauthorize() {
            throw new UnauthorizedAccessException();
        }
    }
}