using Kandoe.Data.EFDB.Connection;

namespace Kandoe.Data.Tests.Fakes {
    public class FakeContext : Context {
        public FakeContext() : base("KandoeDB_EFCodeFirst_Combell_TEST") { }
    }
}
