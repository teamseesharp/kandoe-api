using System;
using System.Collections.Generic;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Connection;
using System.Linq;

namespace Kandoe.Data.EFDB.Repositories {
    public class ThemeRepository : Repository<Theme> {
        public ThemeRepository() : base(new Context()) { }

        public override void Create(Theme entity) {
            this.context.Themes.Add(entity);
            this.context.SaveChanges();
        }

        public override void Delete(int id) {
            var entity = this.Read(id);
            this.context.Themes.Attach(entity);
            this.context.Themes.Remove(entity);
            this.context.SaveChanges();
        }

        public override IEnumerable<Theme> Read(bool lazy = true) {
            return this.context.Themes.AsEnumerable();
        }

        public override Theme Read(int id, bool lazy = true) {
            return this.context.Themes.Find(id);
        }

        public override void Update(Theme entity) {
            this.context.Themes.Attach(entity);
            this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.context.SaveChanges();
        }
    }
}
