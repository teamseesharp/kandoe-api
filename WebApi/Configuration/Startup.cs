﻿using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

[assembly: OwinStartup(typeof(Kandoe.Web.Configuration.Startup))]

namespace Kandoe.Web.Configuration {
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DatabaseConfig.Configure();
            MapperConfig.Configure();
        }
    }
}
