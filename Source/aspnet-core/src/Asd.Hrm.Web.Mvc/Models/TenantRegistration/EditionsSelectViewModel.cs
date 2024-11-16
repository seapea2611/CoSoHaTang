using Abp.AutoMapper;
using Asd.Hrm.MultiTenancy.Dto;

namespace Asd.Hrm.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(EditionsSelectOutput))]
    public class EditionsSelectViewModel : EditionsSelectOutput
    {
    }
}
