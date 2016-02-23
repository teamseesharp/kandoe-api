using System;
using System.Collections.Generic;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Connection;
using System.Linq;

namespace Kandoe.Data.EFDB.Repositories {
    public class SubthemeRepository : Repository<Subtheme> {
        public SubthemeRepository() : base(new Context()) { }

        public override void Create(Subtheme entity) {
            this.context.Subthemes.Add(entity);
            this.context.SaveChanges();
        }

        public override void Delete(int id) {
            var entity = this.Read(id);
            this.context.Subthemes.Attach(entity);
            this.context.Subthemes.Remove(entity);
            this.context.SaveChanges();
        }

        public override IEnumerable<Subtheme> Read(bool lazy = true) {
            return this.context.Subthemes.AsEnumerable();
        }

        public override Subtheme Read(int id, bool lazy = true) {
            return this.context.Subthemes.Find(id);
        }

        public override void Update(Subtheme entity) {
            this.context.Subthemes.Attach(entity);
            this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.context.SaveChanges();
        }
    }
}
