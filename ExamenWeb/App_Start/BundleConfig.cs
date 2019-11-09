using System.Web;
using System.Web.Optimization;

namespace ExamenWeb
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/ckeditor").Include(
                        "~/Scripts/ckeditor/ckeditor.js"));
            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération (bluid) sur http://modernizr.com pour choisir uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            #region Template Desing
            bundles.Add(new ScriptBundle("~/Template/js").Include(
                       "~/Scripts/vendor/jquery-2.2.4.min.js",
                        "~/Scripts/vendor/bootstrap.min.js",
                         "~/Scripts/easing.min.js",
                          "~/Scripts/hoverIntent.js",
                           "~/Scripts/superfish.min.js",
                            "~/Scripts/jquery.ajaxchimp.min.js",
                             "~/Scripts/jquery.magnific-popup.min.js",
                              "~/Scripts/owl.carousel.min.js",
                               "~/Scripts/jquery.sticky.js",
                                "~/Scripts/jquery.nice-select.min.js",
                                 "~/Scripts/parallax.min.js",
                                  "~/Scripts/mail-script.js",
                                   "~/Scripts/main.js"
                                    ));


            bundles.Add(new StyleBundle("~/Template/css").Include(
                     "~/content/css/linearicons.css",
                     "~/content/css/font-awesome.min.css",
                      "~/content/css/bootstrap.css",
                       "~/content/css/magnific-popup.css",
                        "~/content/css/nice-select.css",
                        "~/content/css/animate.min.css",
                        "~/content/css/owl.carousel.css",
                        "~/content/css/main.css",
                        "~/content/css/style.css"));
            #endregion
        }
    }
}
