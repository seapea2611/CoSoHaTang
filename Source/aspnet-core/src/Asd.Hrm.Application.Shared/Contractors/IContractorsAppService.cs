using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Asd.Hrm.Resources.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asd.Hrm.Contractors
{
    public interface IContractorsAppService : IApplicationService
    {
        Task<PagedResultDto<GetContractorsForViewDto>> GetAll(GetAllContractorsInput input);

        Task<GetContractorsForViewDto> GetResourcesForView(int id);

        Task<GetContractorsForEditOutput> GetResourcesForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditContractorsDto input);

        Task Delete(EntityDto input);
    }
}
