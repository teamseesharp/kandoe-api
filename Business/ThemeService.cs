using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Repositories;

namespace Kandoe.Business {
    public class ThemeService : Service<Theme> {
        public ThemeService() : base(new ThemeRepository()) { }
    }
}
