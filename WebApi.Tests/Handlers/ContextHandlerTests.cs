using System.Net.Http;
using System.Threading;

using NUnit.Framework;

using Kandoe.Data.EFDB.Connection;
using Kandoe.Web.Handlers;
using Kandoe.Web.Tests.Fakes;

namespace Kandoe.Web.Tests.Handlers {
    [TestFixture]
    public class ContextHandlerTests {
        [Test]
        public void ProjectContextShouldBeRefreshed() {
            ContextHandler handler = new ContextHandler() {
                InnerHandler = new FakeHttpMessageHandler()
            };

            Context context = ContextFactory.GetContext();

            HttpMessageInvoker invoker = Utilities.createHttpMessageInvoker(handler);
            HttpResponseMessage response = invoker.SendAsync(new HttpRequestMessage(), CancellationToken.None).Result;

            Context refresh = ContextFactory.GetContext();

            Assert.AreNotSame(context, refresh);
        }
    }
}
