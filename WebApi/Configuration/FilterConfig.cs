using System.Web.Mvc;

namespace Kandoe.Web.Configuration {
    public static class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
