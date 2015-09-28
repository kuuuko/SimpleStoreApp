using System.Web;
using System.Web.Optimization;

namespace SimpleStoreApp
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            //Kendo script bundle
            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                        "~/Scripts/kendo/2015.2.902/jquery.min.js",
                        "~/Scripts/kendo/2015.2.902/jszip.min.js",
                        "~/Scripts/kendo/2015.2.902/kendo.all.min.js",
                     // "~/Scripts/kendo/2015.2.902/kendo.timezones.min.js", // uncomment if using the Scheduler
                        "~/Scripts/kendo/2015.2.902/kendo.aspnetmvc.min.js",
                        "~/Scripts/kendo.modernizr.custom.js"
                        ));

            //Kendo style bundle 
            bundles.Add(new StyleBundle("~/Content/kendo/css").Include(
                        "~/Content/kendo.compatibility.css",
                        "~/Content/kendo/2015.2.902/kendo.common.min.css",
                        "~/Content/kendo/2015.2.902/kendo.mobile.all.min.css",
                        "~/Content/kendo/2015.2.902/kendo.dataviz.min.css",
                        "~/Content/kendo/2015.2.902/kendo.default.min.css",
                        "~/Content/kendo/2015.2.902/kendo.dataviz.default.min.css"
                        ));

            //to allow minified files in debug mode...  
            bundles.IgnoreList.Clear();
        }
    }
}