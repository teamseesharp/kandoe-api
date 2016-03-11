using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using Kandoe.Web.Filters;

[assembly: OwinStartup(typeof(Kandoe.Web.Configuration.Startup))]

namespace Kandoe.Web.Configuration {
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            // Register Areas
            AreaRegistration.RegisterAllAreas();

            // Register Web API
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // Register global filters
            GlobalConfiguration.Configuration.Filters.Add(new ExceptionFilter());
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            // Register router
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Register bundles
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Configure the mapper
            MapperConfig.Configure();
        }
    }
}
