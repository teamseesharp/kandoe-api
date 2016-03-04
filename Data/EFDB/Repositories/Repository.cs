using System.Collections.Generic;

using Kandoe.Data.EFDB.Connection;

namespace Kandoe.Data.EFDB.Repositories {
    public abstract class Repository<T> : IRepository<T> {
        protected Context context;

        public Repository(Context context) {
            this.context = context;
        }

        public abstract void Create(T entity);
        public abstract IEnumerable<T> Read(bool eager = false);
        public abstract T Read(int id, bool eager = false);
        public abstract void Update(T entity);
        public abstract void Delete(int id);
    }
}
