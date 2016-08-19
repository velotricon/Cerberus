using System.Web;
using System.Web.Optimization;

namespace Cerberus
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/Angular").Include(
                "~/Scripts/Angular/angular.js",
                "~/Scripts/Angular/angular-route.js",
                "~/Scripts/Angular/angular-loader.js",
                "~/Scripts/Angular/angular-messages.js",
                "~/Scripts/Angular/angular-resource.js",
                "~/Scripts/Angular/angular-sanitize.js",
                "~/Scripts/Angular/angular-animate.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/MainApp").Include(
                "~/Scripts/Modules/Main/ConfigFunction.js",
                "~/Scripts/Modules/Main/Directives/LightComboBoxDirective.js",
                "~/Scripts/Modules/Main/Controllers/AddTranslationController.js",
                "~/Scripts/Modules/Main/Controllers/PersonListController.js",
                "~/Scripts/Modules/Main/Controllers/MainController.js",
                "~/Scripts/Modules/Main/MainApp.js"
                ));
        }
    }
}
