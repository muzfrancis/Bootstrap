using Orchard.UI.Resources;

namespace Bootstrap {
    public class ResourceManifest : IResourceManifestProvider {
        public const string BOOTSWATCH_STYLE = "BOOTSWATCH_STYLE";
        public const string BOOTSTRAP_RESPONSIVE_STYLE = "BOOTSTRAP_RESPONSIVE_STYLE";
        public const string CUSTOM_STYLE = "CUSTOM_STYLE";

        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();

            // core styles
            manifest.DefineStyle(BOOTSWATCH_STYLE).SetUrl("bootswatch.css", "bootswatch.css");
            manifest.DefineStyle(BOOTSTRAP_RESPONSIVE_STYLE).SetUrl("bootstrap-responsive.min.css", "bootstrap-responsive.min.css");
            manifest.DefineStyle(CUSTOM_STYLE).SetUrl("theme.css", "theme.css");

            // swatch
            manifest.DefineStyle("bootstrap.min.css").SetUrl("bootstrap.min.css", "bootstrap.min.css");
            manifest.DefineStyle("amelia.min.css").SetUrl("amelia.min.css", "amelia.min.css");
            manifest.DefineStyle("cerulean.min.css").SetUrl("cerulean.min.css", "cerulean.min.css");
        }
    }
}

