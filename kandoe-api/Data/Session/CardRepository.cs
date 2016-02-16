using System;
using System.Collections.Generic;
using System.Linq;

using Kandoe.Business.Domain;

namespace Kandoe.Data {
    public class CardRepository : Repository<Card> {
        public void Create(Card entity) {
            throw new NotImplementedException();
        }

        public void Delete(int id) {
            throw new NotImplementedException();
        }

        public IEnumerable<Card> Read() {
            throw new NotImplementedException();
        }
        public Card Read(int id) {
            throw new NotImplementedException();
        }

        public void Update(Card entity) {
            throw new NotImplementedException();
        }
    }
}
