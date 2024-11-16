using System.Threading.Tasks;
using Abp.Application.Services;
using Asd.Hrm.Sessions.Dto;

namespace Asd.Hrm.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
