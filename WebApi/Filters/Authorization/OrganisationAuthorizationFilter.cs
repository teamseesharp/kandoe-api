using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Kandoe.Web.Filters.Authorization {
    public class OrganisationAuthorizationAttribute : ActionFilterAttribute {
        public override void OnActionExecuting(HttpActionContext actionContext) {
            string test = Thread.CurrentPrincipal.Identity.Name;
            String s = actionContext.Request.Content.ToString();
            base.OnActionExecuting(actionContext);
        }
    }
}