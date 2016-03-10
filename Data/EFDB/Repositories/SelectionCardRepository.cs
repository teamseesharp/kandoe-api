using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Connection;

namespace Kandoe.Data.EFDB.Repositories {
    public class SelectionCardRepository : Repository<SelectionCard> {
        public SelectionCardRepository() : base(ContextFactory.GetContext()) { }

        public override SelectionCard Create(SelectionCard entity) {
            this.context.SelectionCards.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public override IEnumerable<SelectionCard> Read(bool eager = false) {
            return this.context.SelectionCards.AsEnumerable();
        }

        public override SelectionCard Read(int id, bool eager = false) {
            return this.context.SelectionCards.Find(id);
        }

        public override void Update(SelectionCard entity) {
            this.context.SelectionCards.Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public override void Delete(int id) {
            this.context.SelectionCards.Remove(this.Read(id));
            this.context.SaveChanges();
        }
    }
}
