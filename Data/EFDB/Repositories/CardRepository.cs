using System;
using System.Collections.Generic;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Connection;

namespace Kandoe.Data.EFDB.Repositories {
    public class CardRepository : Repository<Card> {
        public CardRepository() : base(new Context()) { }

        public override void Create(Card entity) {
            throw new NotImplementedException();
        }

        public override void Delete(int id) {
            throw new NotImplementedException();
        }

        public override IEnumerable<Card> Read(bool lazy = true) {
            throw new NotImplementedException();
        }

        public override Card Read(int id, bool lazy = true) {
            throw new NotImplementedException();
        }

        public override void Update(Card entity) {
            throw new NotImplementedException();
        }
    }
}
