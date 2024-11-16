using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Asd.Hrm.Web.Areas.App.Models.Layout;
using Asd.Hrm.Web.Session;
using Asd.Hrm.Web.Views;

namespace Asd.Hrm.Web.Areas.App.Views.Shared.Themes.Default.Components.AppDefaultBrand
{
    public class AppDefaultBrandViewComponent : HrmViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppDefaultBrandViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var headerModel = new HeaderViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(headerModel);
        }
    }
}
