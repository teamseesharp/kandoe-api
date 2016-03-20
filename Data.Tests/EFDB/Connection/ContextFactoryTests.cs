using NUnit.Framework;

using Kandoe.Data.EFDB.Connection;

namespace Kandoe.Data.Tests.EFDB.Connection {
    [TestFixture]
    public class ContextFactoryTests {
        [Test]
        public void ContextCannotBeNull() {
            Assert.NotNull(ContextFactory.GetContext());
        }

        [Test]
        public void ContextShouldBeRefreshed() {
            Context context = ContextFactory.GetContext();

            ContextFactory.Refresh();

            Context refresh = ContextFactory.GetContext();

            Assert.AreNotSame(context, refresh);
        }
    }
}
