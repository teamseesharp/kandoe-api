﻿using System.Collections.Generic;
using System.Data.Entity;

namespace Kandoe.Data.EFDB.Repositories {
    public abstract class Repository<T> : IRepository<T> {
        protected DbContext context;

        public Repository(DbContext context) {
            this.context = context;
        }

        public abstract void Create(T entity);
        public abstract void Delete(int id);
        public abstract IEnumerable<T> Read(bool lazy = true);
        public abstract T Read(int id, bool lazy = true);
        public abstract void Update(T entity);
    }
}