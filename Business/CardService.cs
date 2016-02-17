using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Repositories;

namespace Kandoe.Business {
    public class CardService : Service<Card> {
        public CardService() : base(new CardRepository()) { }
    }
}
