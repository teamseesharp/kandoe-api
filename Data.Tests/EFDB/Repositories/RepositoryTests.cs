using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Connection;
using Kandoe.Data.Tests.Fakes;

namespace Kandoe.Data.Tests.EFDB.Repositories {
    [TestFixture]
    public class RepositoryTests {

        [OneTimeSetUp]
        public void OneTimeSetUp() {

        }

        [SetUp]
        public void SetUp() {
            ContextFactory.Refresh(new FakeContext());
        }
    }
}
