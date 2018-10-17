using System.Web;
using System.Web.Optimization;

namespace ProyectoGISTweets
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.3.1.min.js",
                        "~/Scripts/notify.min.js",
                        "~/Scripts/Custom/Home.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.min.js"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/Template/vendor/bootstrap/js/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/Template/vendor/bootstrap/js/bootstrap.bundle.min.js"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Content/Template/vendor/jquery-easing/jquery.easing.min.js",
            //          "~/Content/Template/vendor/magnific-popup/jquery.magnific-popup.min.js",
            //          "~/Content/Template/vendor/jqBootstrapValidation.js",
            //          "~/Content/Template/vendor/contact_me.js",
            //          "~/Content/Template/vendor/freelancer.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Template/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Content/Template/vendor/font-awesome/css/font-awesome.min.css",
                      "~/Content/Template/vendor/monserrat.css",
                      "~/Content/Template/vendor/lato.css",
                      "~/Content/Template/vendor/magnific-popup/magnific-popup.css",
                      "~/Content/Template/vendor/freelancer.css",
                      "~/Content/Site.css",
                      "~/Content/animate.css"));
        }
    }
}
