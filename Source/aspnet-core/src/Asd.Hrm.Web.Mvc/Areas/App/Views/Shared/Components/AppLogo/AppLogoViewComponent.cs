using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Asd.Hrm.Web.Areas.App.Models.Layout;
using Asd.Hrm.Web.Session;
using Asd.Hrm.Web.Views;

namespace Asd.Hrm.Web.Areas.App.Views.Shared.Components.AppLogo
{
    public class AppLogoViewComponent : HrmViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppLogoViewComponent(
            IPerRequestSessionCache sessionCache
        )
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync(string logoSkin = null, string logoClass = "")
        {
            var headerModel = new LogoViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync(),
                LogoSkinOverride = logoSkin,
                LogoClassOverride = logoClass
            };

            return View(headerModel);
        }
    }
}
