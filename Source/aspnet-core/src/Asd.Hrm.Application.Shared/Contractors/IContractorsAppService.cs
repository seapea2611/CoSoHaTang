using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Asd.Hrm.Contractors.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asd.Hrm.Contractors
{
    public interface IContractorsAppService : IApplicationService
    {
        Task<PagedResultDto<GetContractorsForViewDto>> GetAll(GetAllContractorsInput input);

        Task<GetContractorsForViewDto> GetContractorsForView(int id);

        Task<GetContractorsForEditOutput> GetContractorsForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditContractorsDto input);

        Task Delete(EntityDto input);
    }
}
