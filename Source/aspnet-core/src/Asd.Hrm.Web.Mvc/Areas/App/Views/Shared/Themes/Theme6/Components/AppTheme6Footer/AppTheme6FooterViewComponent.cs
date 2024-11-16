using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Asd.Hrm.Web.Areas.App.Models.Layout;
using Asd.Hrm.Web.Session;
using Asd.Hrm.Web.Views;

namespace Asd.Hrm.Web.Areas.App.Views.Shared.Themes.Theme6.Components.AppTheme6Footer
{
    public class AppTheme6FooterViewComponent : HrmViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppTheme6FooterViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footerModel = new FooterViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(footerModel);
        }
    }
}
