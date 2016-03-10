using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Connection;

namespace Kandoe.Data.EFDB.Repositories {
    public class AccountRepository : Repository<Account> {
        public AccountRepository() : base(ContextFactory.GetContext()) { }

        public override Account Create(Account entity) {
            this.context.Accounts.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public override IEnumerable<Account> Read(bool eager = false) {
            if (eager) {
                return this.context.Accounts
                    .Include(a => a.ChatMessages)
                    .Include(a => a.Organisations)
                    .Include(a => a.OrganisedSessions)
                    .Include(a => a.ParticipatingSessions)
                    .Include(a => a.Subthemes)
                    .Include(a => a.Themes)
                    .AsEnumerable();
            }
            return this.context.Accounts.AsEnumerable();
        }

        public override Account Read(int id, bool eager = false) {
            if (eager) {
                return this.context.Accounts
                    .Include(a => a.ChatMessages)
                    .Include(a => a.Organisations)
                    .Include(a => a.OrganisedSessions)
                    .Include(a => a.ParticipatingSessions)
                    .Include(a => a.Subthemes)
                    .Include(a => a.Themes)
                    .FirstOrDefault(a => a.Id == id);
            }
            return this.context.Accounts.Find(id);
        }

        public override void Update(Account entity) {
            this.context.Accounts.Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public override void Delete(int id) {
            this.context.Accounts.Remove(this.Read(id));
            this.context.SaveChanges();
        }
    }
}
