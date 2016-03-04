using System;
using System.Collections.Generic;
using System.Linq;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Connection;

namespace Kandoe.Data.EFDB.Repositories {
    public class ThemeRepository : Repository<Theme> {
        public ThemeRepository() : base(new Context()) { }

        public override void Create(Theme entity) {
            this.context.Themes.Add(entity);
            this.context.SaveChanges();
        }

        public override IEnumerable<Theme> Read(bool eager = false) {
            return this.context.Themes.AsEnumerable();
        }

        public override Theme Read(int id, bool eager = false) {
            return this.context.Themes.Find(id);
        }

        public override void Update(Theme entity) {
            this.context.Themes.Attach(entity);
            this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.context.SaveChanges();
        }

        public override void Delete(int id) {
            this.context.Themes.Remove(this.Read(id));
            this.context.SaveChanges();
        }
    }
}
