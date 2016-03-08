using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Connection;

namespace Kandoe.Data.EFDB.Repositories {
    public class SubthemeRepository : Repository<Subtheme> {
        public SubthemeRepository() : base(new Context()) { }

        public override void Create(Subtheme entity) {
            this.context.Subthemes.Add(entity);
            this.context.SaveChanges();
        }

        public override IEnumerable<Subtheme> Read(bool eager = false) {
            if (eager) {
                return this.context.Subthemes
                    .Include(st => st.SelectionCards)
                    .Include(st => st.Sessions)
                    .AsEnumerable();
            }
            return this.context.Subthemes.AsEnumerable();
        }

        public override Subtheme Read(int id, bool eager = false) {
            if (eager) {
                return this.context.Subthemes
                    .Include(st => st.SelectionCards)
                    .Include(st => st.Sessions)
                    .FirstOrDefault(st => st.Id == id);
            }
            return this.context.Subthemes.Find(id);
        }

        public override void Update(Subtheme entity) {
            this.context.Subthemes.Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public override void Delete(int id) {
            this.context.Subthemes.Remove(this.Read(id));
            this.context.SaveChanges();
        }
    }
}
