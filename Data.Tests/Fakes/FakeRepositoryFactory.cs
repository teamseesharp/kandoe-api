using Kandoe.Business.Domain;

namespace Kandoe.Data.Tests.Fakes {
    public static class FakeRepositoryFactory {
        public static IRepository<T> Create<T>() where T : Entity {
            return new FakeRepository<T>();
        }
    }
}
