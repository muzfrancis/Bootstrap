using System;
using System.Web;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.UI.Admin;
using Orchard.UI.Resources;
using Orchard.Utility.Extensions;
using Bootstrap.Services;
using Orchard;
using Orchard.Themes.Services;

namespace Bootstrap.Filters {
    public class AlternateCssFilter : FilterProvider, IResultFilter {
        private readonly IThemeSettingsService _settingsService;
        private readonly IResourceManager _resourceManager;
        private readonly ISiteThemeService _siteThemeService;

        public AlternateCssFilter(IThemeSettingsService settingsService, IResourceManager resourceManager, ISiteThemeService siteThemeService) {
            _settingsService = settingsService;
            _resourceManager = resourceManager;
            _siteThemeService = siteThemeService;
        }

        public void OnResultExecuting(ResultExecutingContext filterContext) {
            // ignore filter on admin pages
            if (AdminFilter.IsApplied(filterContext.RequestContext))
                return;

            // should only run on a full view rendering result
            if (!(filterContext.Result is ViewResult))
                return;

            var viewResult = filterContext.Result as ViewResult;
            if (viewResult == null)
                return;

            var themeName = _siteThemeService.GetSiteTheme();
            if (themeName.Name == Constants.THEME_NAME) {
                this.AddMeta();
                this.AddCss();
            }
        }

        private void AddCss() {
            var settings = _settingsService.GetSettings();

            // Add Swatch
            if (!String.IsNullOrEmpty(settings.Swatch))
                _resourceManager.Require("stylesheet", settings.Swatch)
                                .AtHead();

            // Add Bootstrap Responsive
            _resourceManager.Require("stylesheet", ResourceManifest.BOOTSTRAP_RESPONSIVE_STYLE)
                            .AtHead();

            // Add Bootswatch
            _resourceManager.Require("stylesheet", ResourceManifest.BOOTSWATCH_STYLE)
                            .AtHead();

            // Add Theme Overrides
            _resourceManager.Require("stylesheet", ResourceManifest.CUSTOM_STYLE)
                            .AtHead();
        }

        private void AddMeta() {
            // Insert Meta Tags
            _resourceManager.SetMeta(new MetaEntry() {
                Name = "viewport",
                Content = "width=device-width",
            });
        }

        public void OnResultExecuted(ResultExecutedContext filterContext) {
        }
    }
}
