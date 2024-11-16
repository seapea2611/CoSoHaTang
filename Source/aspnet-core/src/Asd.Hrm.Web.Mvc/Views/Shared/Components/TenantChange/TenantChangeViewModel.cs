using Abp.AutoMapper;
using Asd.Hrm.Sessions.Dto;

namespace Asd.Hrm.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}