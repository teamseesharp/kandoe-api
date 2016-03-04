using System.Collections.Generic;
using System.Linq;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Connection;

namespace Kandoe.Data.EFDB.Repositories {
    public class OrganisationRepository : Repository<Organisation> {
        public OrganisationRepository() : base(new Context()) { }

        public override void Create(Organisation entity) {
            this.context.Organisations.Add(entity);
            this.context.SaveChanges();
        }

        public override IEnumerable<Organisation> Read(bool eager = false) {
            return this.context.Organisations.AsEnumerable();
        }

        public override Organisation Read(int id, bool eager = false) {
            return this.context.Organisations.Find(id);
        }

        public override void Update(Organisation entity) {
            this.context.Organisations.Attach(entity);
            this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.context.SaveChanges();
        }

        public override void Delete(int id) {
            this.context.Organisations.Remove(this.Read(id));
            this.context.SaveChanges();
        }
    }
}
