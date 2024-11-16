using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Asd.Hrm.Authorization;
using Asd.Hrm.DashboardCustomization;
using System.Threading.Tasks;
using Asd.Hrm.Web.Areas.App.Startup;

namespace Asd.Hrm.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize(AppPermissions.Pages_Tenant_Dashboard)]
    public class TenantDashboardController : CustomizableDashboardControllerBase
    {
        public TenantDashboardController(DashboardViewConfiguration dashboardViewConfiguration, 
            IDashboardCustomizationAppService dashboardCustomizationAppService) 
            : base(dashboardViewConfiguration, dashboardCustomizationAppService)
        {

        }

        public async Task<ActionResult> Index()
        {
            return await GetView(HrmDashboardCustomizationConsts.DashboardNames.DefaultTenantDashboard);
        }
    }
}