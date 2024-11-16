using Abp.Auditing;
using Asd.Hrm.Configuration.Dto;

namespace Asd.Hrm.Configuration.Tenants.Dto
{
    public class TenantEmailSettingsEditDto : EmailSettingsEditDto
    {
        public bool UseHostDefaultEmailSettings { get; set; }
    }
}