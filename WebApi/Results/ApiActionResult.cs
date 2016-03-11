using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kandoe.Web.Results {
    public class ApiActionResult : IHttpActionResult {
        private readonly string message;
        private readonly HttpStatusCode statusCode;

        public ApiActionResult(HttpStatusCode statusCode, string message) {
            this.statusCode = statusCode;
            this.message = message;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken) {
            HttpResponseMessage response = new HttpResponseMessage(this.statusCode) {
                Content = new StringContent(this.message)
            };
            return Task.FromResult(response);
        }
    }
}