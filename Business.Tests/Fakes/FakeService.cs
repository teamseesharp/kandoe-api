using System;
using System.Collections.Generic;
using System.Linq;

using Kandoe.Business.Domain;
using Kandoe.Data;
using Kandoe.Data.Tests.Fakes;

namespace Kandoe.Business.Tests.Fakes {
    public class FakeService<T> : IService<T> where T : Entity {
        private readonly IRepository<T> repository;

        public FakeService() : this(FakeRepositoryFactory.Create<T>()) { }
        public FakeService(IRepository<T> repository) {
            this.repository = repository;
        }

        public T Add(T entity) { return this.repository.Create(entity); }

        public T Get(int id, bool collections = false) { return this.repository.Read(id, eager: collections); }
        public IEnumerable<T> Get(bool collections = false) { return this.repository.Read(eager: collections); }

        public IEnumerable<T> Get(Func<T, bool> condition, bool collections = false) {
            return this.repository.Read(eager: collections).Where(condition);
        }

        public IEnumerable<T> Get(Func<T, bool> primary, Func<T, bool> secondary, bool collections = false) {
            return this.repository.Read(eager: collections)
                .Where(primary)
                .Where(secondary);
        }

        public IEnumerable<T> Get(Func<T, bool> primary, Func<T, bool> secondary, Func<T, bool> tertiary, bool collections = false) {
            return this.repository.Read(eager: collections)
                .Where(primary)
                .Where(secondary)
                .Where(tertiary);
        }

        public void Change(T entity) { this.repository.Update(entity); }

        public void Remove(int id) { this.repository.Delete(id); }
    }
}
