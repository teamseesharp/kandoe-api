using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

using Kandoe.Web.Handlers.Auth0;

namespace Kandoe.Web.Handlers {
    public class AuthenticationHandler : DelegatingHandler {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string SymmetricKey { get; set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            HttpResponseMessage response = null;

            if (HasValidAuthorizationHeader(request)) {
                try {
                    string token = RetrieveToken(request);
                    string secret = this.SymmetricKey.Replace('-', '+').Replace('_', '/');

                    Thread.CurrentPrincipal = JsonWebToken.ValidateToken(
                        token,
                        secret,
                        audience: this.Audience,
                        checkExpiration: true,
                        issuer: this.Issuer
                    );

                    if (HttpContext.Current != null) {
                        HttpContext.Current.User = Thread.CurrentPrincipal;
                    }
                } catch (JWT.SignatureVerificationException e) {
                    response = new HttpResponseMessage(HttpStatusCode.Unauthorized) {
                        Content = new StringContent(e.Message)
                    };
                } catch (JsonWebToken.TokenValidationException e) {
                    response = new HttpResponseMessage(HttpStatusCode.Unauthorized) {
                        Content = new StringContent(e.Message)
                    };
                } catch (Exception e) {
                    response = new HttpResponseMessage(HttpStatusCode.InternalServerError) {
                        Content = new StringContent(e.Message)
                    };
                }
            }

            return response != null ?
                Task.FromResult(response) :
                base.SendAsync(request, cancellationToken);
        }

        private static bool HasValidAuthorizationHeader(HttpRequestMessage request) {
            int count = request.Headers.Where(header => header.Key == "Authorization").Count();

            bool hasSingleAuthorizationHeader = (count == 1);
            if (!hasSingleAuthorizationHeader) { return false; }

            bool hasBearerScheme = (request.Headers.Authorization.Scheme == "Bearer");

            return hasBearerScheme;
        }

        private static string RetrieveToken(HttpRequestMessage request) {
            return request.Headers.Authorization.Parameter;
        }
    }
}
