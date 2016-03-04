using System.Collections.Generic;
using System.Linq;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Connection;

namespace Kandoe.Data.EFDB.Repositories {
    public class CardRepository : Repository<Card> {
        public CardRepository() : base(new Context()) { }

        public override void Create(Card entity) {
            this.context.Cards.Add(entity);
            this.context.SaveChanges();
        }

        public override IEnumerable<Card> Read(bool eager = false) {
            return this.context.Cards.AsEnumerable();
        }

        public override Card Read(int id, bool eager = false) {
            return this.context.Cards.Find(id);
        }

        public override void Update(Card entity) {
            this.context.Cards.Attach(entity);
            this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.context.SaveChanges();
        }

        public override void Delete(int id) {
            this.context.Cards.Remove(this.Read(id));
            this.context.SaveChanges();
        }
    }
}
