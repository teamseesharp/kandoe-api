using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Kandoe.Data;

namespace Kandoe.Business {
    public abstract class Service<T> {
        public Service(IRepository<T> repository) {
            this.Repository = repository;
        }

        protected IRepository<T> Repository { get; set; } 

        public void Add(T entity) { this.Repository.Create(entity); }

        public T Get(int id) { return this.Repository.Read(id); }
        public IEnumerable<T> Get() { return this.Repository.Read(); }

        public void Change(T entity) { this.Repository.Update(entity); }

        public void Remove(int id) { this.Repository.Delete(id); }
    }
}
