using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Repositories;

namespace Kandoe.Business {
    public class OrganisationService : Service<Organisation> {
        public OrganisationService() : base(new OrganisationRepository()) { }
    }
}
