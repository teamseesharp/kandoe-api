using System.Collections.Generic;
using System.Linq;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Connection;

namespace Kandoe.Data.EFDB.Repositories {
    public class CardReviewRepository : Repository<CardReview> {
        public CardReviewRepository() : base(new Context()) { }

        public override void Create(CardReview entity) {
            this.context.CardReviews.Add(entity);
            this.context.SaveChanges();
        }

        public override IEnumerable<CardReview> Read(bool eager = false) {
            return this.context.CardReviews.AsEnumerable();
        }

        public override CardReview Read(int id, bool eager = false) {
            return this.context.CardReviews.Find(id);
        }

        public override void Update(CardReview entity) {
            this.context.CardReviews.Attach(entity);
            this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.context.SaveChanges();
        }

        public override void Delete(int id) {
            this.context.CardReviews.Remove(this.Read(id));
            this.context.SaveChanges();
        }
    }
}
