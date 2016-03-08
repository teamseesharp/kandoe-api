using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Repositories;

namespace Kandoe.Business {
    public class SessionCardService : Service<SessionCard> {
        public SessionCardService() : base(new SessionCardRepository()) { }
    }
}
