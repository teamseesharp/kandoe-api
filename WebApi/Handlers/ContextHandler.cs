using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

using Kandoe.Data.EFDB.Connection;
using Kandoe.Web.Handlers.Auth0;

namespace Kandoe.Web.Handlers {
    public class ContextHandler : DelegatingHandler {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            ContextFactory.Refresh();
            return base.SendAsync(request, cancellationToken);
        }
    }
}
