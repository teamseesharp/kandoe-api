using System.Collections.Generic;

namespace Kandoe.Data {
    public interface IRepository<T> {
        T Create(T entity);

        T Read(int id, bool eager = false);
        IEnumerable<T> Read(bool eager = false);

        void Update(T entity);

        void Delete(int id);
    }
}
