using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using Kandoe.Data.EFDB.Connection;

[assembly: OwinStartup(typeof(Kandoe.Web.Configuration.Startup))]

namespace Kandoe.Web.Configuration {
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            MapperConfig.Configure();

            

            /*
            // Create and initialize local database here, because AuthConfig uses the same database
            Context ctx = new Context();
            ctx.Database.Initialize(true);
            */
        }
    }
}
