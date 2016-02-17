using System.Collections.Generic;

namespace Kandoe.Business {
    public interface IService<T> {
        void Add(T entity);

        T Get(int id);
        IEnumerable<T> Get();

        void Change(T entity);

        void Remove(int id);
    }
}
