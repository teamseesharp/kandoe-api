using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kandoe.Business {
    public interface Service<T> {
        void Add(T entity);

        T Get(int id);
        IEnumerable<T> Get();

        void Change(T entity);

        void Remove(int id);
    }
}
