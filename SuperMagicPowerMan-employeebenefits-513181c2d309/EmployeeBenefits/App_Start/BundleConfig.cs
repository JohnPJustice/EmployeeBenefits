using System.Web;
using System.Web.Optimization;

namespace EmployeeBenefits
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/app")/*.IncludeDirectory("~/Scripts/app/controllers", "*.js")*/.Include("~/Scripts/app/app.js"));


            BundleTable.EnableOptimizations = true;
        }
    }
}
