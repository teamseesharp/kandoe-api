using System.Web.Optimization;

namespace Kandoe.Web.Configuration {
    public static class BundleConfig {
        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/scripts/jquery-{version}.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/scripts/modernizr-*"
            ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/scripts/bootstrap.js",
                      "~/Content/scripts/respond.js"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/site.css"
            ));
        }
    }
}
