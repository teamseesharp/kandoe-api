using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Connection;

namespace Kandoe.Data.EFDB.Repositories {
    public class SessionRepository : Repository<Session> {
        public SessionRepository() : base(ContextFactory.GetContext()) { }
        public SessionRepository(Context context) : base(context) { }

        public override Session Create(Session entity) {
            this.context.Sessions.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public override IEnumerable<Session> Read(bool eager = false) {
            if (eager) {
                return this.context.Sessions
                    .Include(s => s.ChatMessages)
                    .Include(s => s.Invitees)
                    .Include(s => s.Organisers)
                    .Include(s => s.Participants)
                    .Include(s => s.SessionCards)
                    .AsEnumerable();
            }
            return this.context.Sessions.AsEnumerable();
        }

        public override Session Read(int id, bool eager = false) {
            if (eager) {
                return this.context.Sessions
                    .Include(s => s.ChatMessages)
                    .Include(s => s.Invitees)
                    .Include(s => s.Organisers)
                    .Include(s => s.Participants)
                    .Include(s => s.SessionCards)
                    .FirstOrDefault(s => s.Id == id);
            }
            return this.context.Sessions.Find(id);
        }

        public override void Update(Session entity) {
            this.context.Sessions.Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public override void Delete(int id) {
            this.context.Sessions.Remove(this.Read(id));
            this.context.SaveChanges();
        }
    }
}
