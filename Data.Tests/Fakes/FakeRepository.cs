using System.Collections.Generic;

using Kandoe.Business.Domain;

namespace Kandoe.Data.Tests.Fakes {
    public class FakeRepository<T> : IRepository<T> where T : Entity {
        private readonly List<T> entities;

        public FakeRepository() {
            this.entities = new List<T>();
        }

        public T Create(T entity) {
            entity.Id = this.entities.Count + 1;
            this.entities.Add(entity);
            return entity;
        }

        public void Delete(int id) {
            this.entities.RemoveAt(id - 1);
        }

        public IEnumerable<T> Read(bool eager = false) {
            return this.entities;
        }

        public T Read(int id, bool eager = false) {
            return this.entities[id - 1];
        }

        public void Update(T entity) {
            this.entities[entity.Id - 1] = entity;
        }
    }
}
