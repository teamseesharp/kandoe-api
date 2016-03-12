using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;

using Kandoe.Web.Handlers;

namespace Kandoe.Web.Configuration {
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API configuration and services
            EnableCorsAttribute cors = new EnableCorsAttribute("http://localhost:9000", "*", "*");
            config.EnableCors(cors);

            var clientID = WebConfigurationManager.AppSettings["auth0:ClientId"];
            var clientSecret = WebConfigurationManager.AppSettings["auth0:ClientSecret"];

            config.MessageHandlers.Add(new AuthenticationHandler() {
                Audience = clientID,            // client id
                SymmetricKey = clientSecret     // client secret
            });

            // Web API routes
            config.MapHttpAttributeRoutes();

            /* Default */
            config.Routes.MapHttpRoute(
                name: "Api",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
