using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace _16122023_BlogSitesi.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundle(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;

            // Style
            bundles.Add(
                new StyleBundle("~/style/custom")
                .Include("~/Content/Site.css"));

            bundles.Add(
                new StyleBundle("~/style/bootstrap")
                .Include("~/Content/bootstrap.min.css"));


            // Script

            bundles.Add(
                new ScriptBundle("~/script/modernizr")
                .Include("~/Scripts/modernizr-2.6.2.js"));

            bundles.Add(
                new ScriptBundle("~/script/jquery")
                .Include("~/Scripts/jquery-1.10.2.min.js"));

            bundles.Add(
                new ScriptBundle("~/script/bootstrap")
                .Include("~/Scripts/bootstrap.min.js"));

            bundles.Add(
                new ScriptBundle("~/script/validations")
                .Include(
                    "~/Scripts/jquery.validate.min.js",
                    "~/Scripts/jquery.validate.unobtrusive.min.js"));

            bundles.Add(
                new ScriptBundle("~/script/fontawesome")
                .Include("~/Content/fontawesome/js/all.min.js"));

        }
    }
}