using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Connection;

namespace Kandoe.Data.EFDB.Repositories {
    public class ThemeRepository : Repository<Theme> {
        public ThemeRepository() : base(ContextFactory.GetContext()) { }
        public ThemeRepository(Context context) : base(context) { }

        public override Theme Create(Theme entity) {
            this.context.Themes.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public override IEnumerable<Theme> Read(bool eager = false) {
            if (eager) {
                return this.context.Themes
                    .Include(t => t.SelectionCards)
                    .Include(t => t.Subthemes)
                    .AsEnumerable();
            }
            return this.context.Themes.AsEnumerable();
        }

        public override Theme Read(int id, bool eager = false) {
            if (eager) {
                return this.context.Themes
                    .Include(t => t.SelectionCards)
                    .Include(t => t.Subthemes)
                    .SingleOrDefault(t => t.Id == id);
            }
            return this.context.Themes.Find(id);
        }

        public override void Update(Theme entity) {
            this.context.Themes.Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public override void Delete(int id) {
            this.context.Themes.Remove(this.Read(id));
            this.context.SaveChanges();
        }
    }
}
