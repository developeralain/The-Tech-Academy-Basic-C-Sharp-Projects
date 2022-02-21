using System.Web;
using System.Web.Optimization;

namespace NewsletterAppMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(//these files being referenced exists within our Scripts folder 
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(//here it's bundling bootstrap and site.css files together, which exist locally in our Content folder
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
/*
What does bundling in general do? 
    Bundling takes a bunch of files--css, javascript, etc--and packs them together in a 'bundle'
    If there's a minified version--meaning all white space has been taken out--it uses that and saves a lot of space


*/