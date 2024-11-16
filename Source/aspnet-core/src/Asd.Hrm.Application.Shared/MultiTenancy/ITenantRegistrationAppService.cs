using System.Threading.Tasks;
using Abp.Application.Services;
using Asd.Hrm.Editions.Dto;
using Asd.Hrm.MultiTenancy.Dto;

namespace Asd.Hrm.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}