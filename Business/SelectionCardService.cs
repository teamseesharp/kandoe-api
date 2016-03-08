using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Repositories;

namespace Kandoe.Business {
    public class SelectionCardService : Service<SelectionCard> {
        public SelectionCardService() : base(new SelectionCardRepository()) { }
    }
}
