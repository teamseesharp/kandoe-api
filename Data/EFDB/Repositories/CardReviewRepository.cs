using System;
using System.Collections.Generic;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Connection;

namespace Kandoe.Data.EFDB.Repositories {
    public class CardReviewRepository : Repository<CardReview> {
        public CardReviewRepository() : base(new Context()) { }

        public override void Create(CardReview entity) {
            throw new NotImplementedException();
        }

        public override void Delete(int id) {
            throw new NotImplementedException();
        }

        public override IEnumerable<CardReview> Read(bool lazy = true) {
            throw new NotImplementedException();
        }

        public override CardReview Read(int id, bool lazy = true) {
            throw new NotImplementedException();
        }

        public override void Update(CardReview entity) {
            throw new NotImplementedException();
        }
    }
}
