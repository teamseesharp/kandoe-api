using Kandoe.Business.Domain;
using Kandoe.Data;

namespace Kandoe.Business.Tests.Fakes {
    public static class FakeServiceFactory {
        public static IService<T> Create<T>() where T : Entity {
            return new FakeService<T>();
        }
        public static IService<T> Create<T>(IRepository<T> repository) where T : Entity {
            return new FakeService<T>(repository);
        }
    }
}
