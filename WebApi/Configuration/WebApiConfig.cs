﻿using System.Web.Http;
using Microsoft.Owin.Security.OAuth;

namespace Kandoe.Web.Configuration {
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            /*
            config.Routes.MapHttpRoute(
                name: "Card",
                routeTemplate: "api/card/{id}",
                defaults: new { controller = "Card", id = RouteParameter.Optional },
                constraints: new { controller = "Card" }
            );*/

            /* Default */
            config.Routes.MapHttpRoute(
                name: "Api",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}