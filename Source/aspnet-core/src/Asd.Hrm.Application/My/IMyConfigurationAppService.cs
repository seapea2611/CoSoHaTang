using Abp.Application.Services;
using System.Threading.Tasks;

namespace Asd.Hrm.My
{
    public interface IMyConfigurationAppService : IApplicationService
    {
        Task<MyConfigurationDto> GetMyConfiguration();
    }
}
