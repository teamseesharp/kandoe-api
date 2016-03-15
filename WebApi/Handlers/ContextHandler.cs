using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Kandoe.Data.EFDB.Connection;

namespace Kandoe.Web.Handlers {
    public class ContextHandler : DelegatingHandler {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            ContextFactory.Refresh();
            return base.SendAsync(request, cancellationToken);
        }
    }
}
