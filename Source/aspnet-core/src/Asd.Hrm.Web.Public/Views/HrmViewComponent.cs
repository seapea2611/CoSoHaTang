using Abp.AspNetCore.Mvc.ViewComponents;

namespace Asd.Hrm.Web.Public.Views
{
    public abstract class HrmViewComponent : AbpViewComponent
    {
        protected HrmViewComponent()
        {
            LocalizationSourceName = HrmConsts.LocalizationSourceName;
        }
    }
}