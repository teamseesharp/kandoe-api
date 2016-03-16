using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Dispatcher;

using NUnit.Framework;

using Kandoe.Web.Auth0;
using Kandoe.Web.Handlers;

namespace WebApi.Tests.Handlers {
    [TestFixture]
    public class AuthenticationHandlerTests {
        private string validToken;
        private string invalidToken;

        private string scheme;

        private AuthenticationHandler handler;

        [SetUp]
        public void SetUp() {
            TokenFactory.Configure();

            this.validToken = TokenFactory.GetToken();
            this.invalidToken = TokenFactory.GetInvalidToken();

            this.scheme = "Bearer";

            string clientId = WebConfigurationManager.AppSettings["auth0:ClientId"];
            string clientSecret = WebConfigurationManager.AppSettings["auth0:ClientSecret"];

            this.handler = new AuthenticationHandler {
                Audience = clientId,            // client id
                SymmetricKey = clientSecret,     // client secret
                InnerHandler = new HttpControllerDispatcher(new HttpConfiguration())
            };

            HttpWorkerRequest initWorkerRequest = new SimpleWorkerRequest("", "", "", "", new StringWriter(CultureInfo.InvariantCulture));
            HttpContext.Current = new HttpContext(initWorkerRequest);
        }

        [Test]
        public void ShouldNotBeAuthenticated() {
            CancellationToken cancellationToken = CancellationToken.None;
            HttpRequestMessage request = new HttpRequestMessage();

            request.Headers.Authorization = new AuthenticationHeaderValue(this.scheme, this.invalidToken);

            HttpMessageInvoker invoker = Utilities.createHttpMessageInvoker(this.handler);
            HttpResponseMessage response = invoker.SendAsync(request, cancellationToken).Result;

            Assert.AreEqual(response.StatusCode, HttpStatusCode.Unauthorized);
        }

        [Test]
        public void ShouldBeAuthenticated() {
            CancellationToken cancellationToken = CancellationToken.None;
            HttpRequestMessage request = new HttpRequestMessage();

            request.Headers.Authorization = new AuthenticationHeaderValue(this.scheme, this.validToken);

            HttpMessageInvoker invoker = Utilities.createHttpMessageInvoker(this.handler);
            HttpResponseMessage response = invoker.SendAsync(request, cancellationToken).Result;

            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        public void ShouldFillCurrentPrincipalOnSuccessfulAuthentication() {

        }

        [Test]
        public void ShouldNotFillCurrentPrincipalOnFailedAuthentication() {

        }
    }
}
