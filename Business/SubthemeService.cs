using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Repositories;

namespace Kandoe.Business {
    public class SubthemeService : Service<Subtheme> {
        public SubthemeService() : base(new SubthemeRepository()) { }
    }
}
