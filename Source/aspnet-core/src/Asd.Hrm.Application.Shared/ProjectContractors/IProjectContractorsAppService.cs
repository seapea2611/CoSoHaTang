using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Asd.Hrm.ProjectContractors.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asd.Hrm.ProjectContractors
{
    public interface IProjectContractorsAppService : IApplicationService
    {
        Task<PagedResultDto<GetProjectContractorsForViewDto>> GetAll(GetAllProjectContractorsInput input);

        Task<GetProjectContractorsForViewDto> GetProjectContractorsForView(int id);

        Task<GetProjectContractorsForEditOutput> GetProjectContractorsForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditProjectContractorsDto input);

        Task Delete(EntityDto input);
    }
}