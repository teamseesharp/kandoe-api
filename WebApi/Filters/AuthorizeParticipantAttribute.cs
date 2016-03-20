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
    public class AuthorizeParticipantAttribute : ActionFilterAttribute {
        public AuthorizeParticipantAttribute() {
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
                case "POST":
                    this.AuthorizePost(actionContext);
                    break;
                default:
                    this.Unauthorize();
                    break;
            }

            base.OnActionExecuting(actionContext);
        }

        public void AuthorizeParticipant(int participantId) {
            // issuer secret
            string secret = Thread.CurrentPrincipal.Identity.Name;
            // participant secret
            Account participant = this.Accounts.Get(participantId);

            // if account does not exist
            if (participant == null) {
                this.Unauthorize();
            }

            // unauthorized action if issuer != participant
            if (participant.Secret != secret) {
                this.Unauthorize();
            }
        }

        public void AuthorizeParticipant(ICollection<Account> participants) {
            // issuer secret
            string secret = Thread.CurrentPrincipal.Identity.Name;
            // participant secret
            Account participant = this.Accounts.Get(a => a.Secret == secret).FirstOrDefault();

            // if account does not exist or there are no participants
            if (participant == null || participants == null) {
                this.Unauthorize();
            }

            // unauthorized action if issuer != participant
            if (!participants.Contains(participant)) {
                this.Unauthorize();
            }
        }

        private void AuthorizePost(HttpActionContext actionContext) {
            int participantId;

            string controller = actionContext.ControllerContext.ControllerDescriptor.ControllerName;

            switch (controller) {
                case "ChatMessage":
                    ChatMessageDto message = (ChatMessageDto) actionContext.ActionArguments["dto"];
                    Session session = this.Sessions.Get(message.SessionId, collections: true);

                    this.AuthorizeParticipant(session.Participants);

                    return;
                default:    // to prevent the dto from being null
                    participantId = -1;
                    break;
            }

            this.AuthorizeParticipant(participantId);
        }

        private void AuthorizePatch(HttpActionContext actionContext) {
            int participantId;

            string controller = actionContext.ControllerContext.ControllerDescriptor.ControllerName;

            switch (controller) {
                case "Session":
                    int id = (int) actionContext.RequestContext.RouteData.Values["id"];
                    Session session = this.Sessions.Get(id, collections: true);

                    this.AuthorizeParticipant(session.Participants);

                    return;
                default:    // will be unauthorized
                    participantId = -1;
                    break;
            }

            this.AuthorizeParticipant(participantId);
        }

        public void Unauthorize() {
            throw new UnauthorizedAccessException();
        }
    }
}