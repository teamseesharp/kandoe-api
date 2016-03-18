using System;
using System.Collections.Generic;

namespace Kandoe.Business {
    public interface IService<T> {
        T Add(T entity);

        T Get(int id, bool collections = false);
        IEnumerable<T> Get(bool collections = false);
        IEnumerable<T> Get(Func<T, bool> condition, bool collections = false);
        IEnumerable<T> Get(Func<T, bool> primary, Func<T, bool> secondary, bool collections = false);
        IEnumerable<T> Get(Func<T, bool> primary, Func<T, bool> secondary, Func<T, bool> tertiary, bool collections = false);

        void Change(T entity);

        void Remove(int id);
    }
}
