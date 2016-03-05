using System.Collections.Generic;
using System.Data.Entity;
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
            if (eager) {
                return this.context.Cards
                    .Include(c => c.CardReviews)
                    .Include(c => c.Sessions)
                    .Include(c => c.Subthemes)
                    .AsEnumerable();
            }
            return this.context.Cards.AsEnumerable();
        }

        public override Card Read(int id, bool eager = false) {
            if (eager) {
                return this.context.Cards
                    .Include(c => c.CardReviews)
                    .Include(c => c.Sessions)
                    .Include(c => c.Subthemes)
                    .FirstOrDefault(c => c.Id == id);
            }
            return this.context.Cards.Find(id);
        }

        public override void Update(Card entity) {
            this.context.Cards.Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public override void Delete(int id) {
            this.context.Cards.Remove(this.Read(id));
            this.context.SaveChanges();
        }
    }
}
