using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Kandoe.Web.Configuration {
    public static class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Documentation",
                url: "{controller}/{action}",
                defaults: new { controller = "Documentation", action = "Index" }
            );
        }
    }
}
