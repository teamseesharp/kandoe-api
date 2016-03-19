using NUnit.Framework;

using Kandoe.Data.EFDB.Connection;

namespace WebApi.Tests.Handlers {
    [TestFixture]
    public class ContextHandlerTests {
        [Test]
        public void ProjectContextShouldBeRefreshed() {
            Context context = ContextFactory.GetContext();

            // async shit hier

            Context refresh = ContextFactory.GetContext();

            Assert.AreNotSame(context, refresh);
        }
    }
}
