using System.Net.Http;
using System.Threading;

using NUnit.Framework;

using Kandoe.Data.EFDB.Connection;
using Kandoe.Web.Handlers;

namespace WebApi.Tests.Handlers {
    [TestFixture]
    public class ContextHandlerTests {
        [Test]
        public void ProjectContextShouldBeRefreshed() {
            Context context = ContextFactory.GetContext();
            ContextHandler handler = new ContextHandler() {
                InnerHandler = new ContextHandler()
            };

            // async shit hier
            HttpMessageInvoker invoker = Utilities.createHttpMessageInvoker(handler);
            HttpResponseMessage response = invoker.SendAsync(new HttpRequestMessage(), CancellationToken.None).Result;

            Context refresh = ContextFactory.GetContext();

            Assert.AreNotSame(context, refresh);
        }
    }
}
