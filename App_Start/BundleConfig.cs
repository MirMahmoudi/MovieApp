﻿using System.Web;
using System.Web.Optimization;

namespace MovieApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootbox.js",
                        "~/Scripts/dataTables/jquery.dataTables.js",
                        "~/Scripts/dataTables/dataTables.bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      //"~/Content/bootstrap.css",
                      //"~/Content/bootstrap-cerulean.css",0
                      //"~/Content/bootstrap-cosmo.css",00
                      //"~/Content/bootstrap-cyborg.css",
                      //"~/Content/bootstrap-darkly.css",
                      //"~/Content/bootstrap-flatly.css",
                      //"~/Content/bootstrap-journal.css",
                      //"~/Content/bootstrap-lumen.css",
                      "~/Content/bootstrap-paper.css",
                      //"~/Content/bootstrap-readable.css",
                      //"~/Content/bootstrap-sandstone.css",
                      //"~/Content/bootstrap-simplex.css",
                      //"~/Content/bootstrap-slate.css",
                      //"~/Content/bootstrap-spacelab.css",00
                      //"~/Content/bootstrap-superhero.css",
                      //"~/Content/bootstrap-united.css",
                      //"~/Content/bootstrap-yeti.css",
                      "~/Content/DataTables/css/dataTables.bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
