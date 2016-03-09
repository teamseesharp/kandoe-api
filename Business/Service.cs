using System;
using System.Collections.Generic;
using System.Linq;

using Kandoe.Data;

namespace Kandoe.Business {
    public abstract class Service<T> : IService<T> {
        public Service(IRepository<T> repository) {
            this.Repository = repository;
        }

        protected IRepository<T> Repository { get; set; } 

        public T Add(T entity) { return this.Repository.Create(entity); }

        public virtual T Get(int id, bool collections = false) { return this.Repository.Read(id, eager: collections); }
        public virtual IEnumerable<T> Get(bool collections = false) { return this.Repository.Read(eager: collections); }
        public virtual IEnumerable<T> Get(Func<T, bool> condition, bool collections = false) {
            return this.Repository.Read(eager: collections).Where(condition);
        }

        public virtual void Change(T entity) { this.Repository.Update(entity); }

        public virtual void Remove(int id) { this.Repository.Delete(id); }
    }
}
