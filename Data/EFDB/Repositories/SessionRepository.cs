using System;
using System.Collections.Generic;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Connection;
using System.Linq;

namespace Kandoe.Data.EFDB.Repositories {
    public class SessionRepository : Repository<Session> {
        public SessionRepository() : base(new  Context()) { }

        public override void Create(Session entity) {
            this.context.Sessions.Add(entity);
            this.context.SaveChanges();
        }

        public override void Delete(int id) {
            var entity = this.Read(id);
            this.context.Sessions.Attach(entity);
            this.context.Sessions.Remove(entity);
            this.context.SaveChanges();
        }

        public override IEnumerable<Session> Read(bool lazy = true) {
            return this.context.Sessions.AsEnumerable();
        }

        public override Session Read(int id, bool lazy = true) {
            return this.context.Sessions.Find(id);
        }

        public override void Update(Session entity) {
            this.context.Sessions.Attach(entity);
            this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.context.SaveChanges();
        }
    }
}
