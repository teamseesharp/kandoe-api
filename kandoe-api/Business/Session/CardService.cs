using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Kandoe.Business.Domain;
using Kandoe.Data;

namespace Kandoe.Business {
    public class CardService : Service<Card> {
        private readonly CardRepository repo;

        public CardService() {
            this.repo = new CardRepository();
        }

        public void Add(Card entity) { this.repo.Create(entity); }

        public void Change(Card entity) { this.repo.Update(entity); }

        public Card Get(int id) { return this.repo.Read(id); }
        public IEnumerable<Card> Get() { return this.repo.Read(); }

        public void Remove(int id) { this.repo.Delete(id); }
    }
}
