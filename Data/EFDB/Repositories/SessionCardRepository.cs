using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Connection;

namespace Kandoe.Data.EFDB.Repositories {
    public class SessionCardRepository : Repository<SessionCard> {
        public SessionCardRepository() : base(new Context()) { }

        public override void Create(SessionCard entity) {
            this.context.SessionCards.Add(entity);
            this.context.SaveChanges();
        }

        public override IEnumerable<SessionCard> Read(bool eager = false) {
            return this.context.SessionCards.AsEnumerable();
        }

        public override SessionCard Read(int id, bool eager = false) {
            return this.context.SessionCards.Find(id);
        }

        public override void Update(SessionCard entity) {
            this.context.SessionCards.Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public override void Delete(int id) {
            this.context.SessionCards.Remove(this.Read(id));
            this.context.SaveChanges();
        }
    }
}
