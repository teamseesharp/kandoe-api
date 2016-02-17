using System.Collections.Generic;

namespace Kandoe.Data {
    public interface IRepository<T> {
        void Create(T entity);

        T Read(int id, bool lazy = true);
        IEnumerable<T> Read(bool lazy = true);

        void Update(T entity);

        void Delete(int id);
    }
}
