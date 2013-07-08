using System.Web.Mvc;
using Orchard;
using Orchard.Localization;
using Orchard.UI.Notify;
using Bootstrap.ViewModels;
using Bootstrap.Services;

namespace Bootstrap.Controllers {
    [ValidateInput(false)]
    public class AdminController : Controller {
        private readonly IThemeSettingsService _settingsService;

        public AdminController(
            IOrchardServices services,
            IThemeSettingsService settingsService) {
            _settingsService = settingsService;
            Services = services;
            T = NullLocalizer.Instance;
        }

        public IOrchardServices Services { get; set; }
        public Localizer T { get; set; }

        public ActionResult Index() {
            var settings = _settingsService.GetSettings();

            var viewModel = new ThemeSettingsViewModel {
                Swatch = settings.Swatch,
                UseFixedHeader = settings.UseFixedHeader,
                UseFluidLayout = settings.UseFluidLayout,
                UseInverseHeader = settings.UseInverseHeader,
                UseStickyFooter = settings.UseStickyFooter
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(ThemeSettingsViewModel viewModel) {
            if (!Services.Authorizer.Authorize(Bootstrap.Permissions.ManageThemeSettings, T("Couldn't update Bootstrap settings")))
                return new HttpUnauthorizedResult();

            var settings = _settingsService.GetSettings();
            settings.Swatch = viewModel.Swatch;
            settings.UseFixedHeader = viewModel.UseFixedHeader;
            settings.UseFluidLayout = viewModel.UseFluidLayout;
            settings.UseInverseHeader = viewModel.UseInverseHeader;
            settings.UseStickyFooter = viewModel.UseStickyFooter;

            Services.Notifier.Information(T("Your settings have been saved."));

            return View(viewModel);
        }
    }
}
