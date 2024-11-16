using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace Asd.Hrm.Web.Public.Views
{
    public abstract class HrmRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected HrmRazorPage()
        {
            LocalizationSourceName = HrmConsts.LocalizationSourceName;
        }
    }
}
