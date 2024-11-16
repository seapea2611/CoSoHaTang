using Abp.AspNetCore.Mvc.Views;

namespace Asd.Hrm.Web.Views
{
    public abstract class HrmRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected HrmRazorPage()
        {
            LocalizationSourceName = HrmConsts.LocalizationSourceName;
        }
    }
}
