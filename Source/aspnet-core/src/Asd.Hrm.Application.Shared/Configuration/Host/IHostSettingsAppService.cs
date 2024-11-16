using System.Threading.Tasks;
using Abp.Application.Services;
using Asd.Hrm.Configuration.Host.Dto;

namespace Asd.Hrm.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
