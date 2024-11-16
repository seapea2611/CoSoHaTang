using System.Threading.Tasks;
using Abp.Application.Services;
using Asd.Hrm.Install.Dto;

namespace Asd.Hrm.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}