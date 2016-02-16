using System.Collections.Generic;

namespace Kandoe.Data {
    public interface Repository<T> {
        void Create(T entity);

        T Read(int id);
        IEnumerable<T> Read();

        void Update(T entity);

        void Delete(int id);

    }
}
