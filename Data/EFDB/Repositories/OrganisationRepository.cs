using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Connection;

namespace Kandoe.Data.EFDB.Repositories {
    public class OrganisationRepository : Repository<Organisation> {
        public OrganisationRepository() : base(ContextFactory.GetContext()) { }

        public override Organisation Create(Organisation entity) {
            this.context.Organisations.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public override IEnumerable<Organisation> Read(bool eager = false) {
            if (eager) {
                return this.context.Organisations
                    .Include(o => o.Sessions)
                    .Include(o => o.Themes.Select(t => t.Subthemes))
                    .AsEnumerable();
            }
            return this.context.Organisations.AsEnumerable();
        }

        public override Organisation Read(int id, bool eager = false) {
            if (eager) {
                return this.context.Organisations
                    .Include(o => o.Sessions)
                    .Include(o => o.Themes)
                    .FirstOrDefault(o => o.Id == id);
            }
            return this.context.Organisations.Find(id);
        }

        public override void Update(Organisation entity) {
            this.context.Organisations.Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public override void Delete(int id) {
            this.context.Organisations.Remove(this.Read(id));
            this.context.SaveChanges();
        }
    }
}
