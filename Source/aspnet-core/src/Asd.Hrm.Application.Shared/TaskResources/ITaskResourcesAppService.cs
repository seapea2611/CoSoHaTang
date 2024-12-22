using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Asd.Hrm.TaskResources.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asd.Hrm.TaskResources
{
    public interface ITaskResourcesAppService : IApplicationService
    {
        Task<PagedResultDto<GetTaskResourcesForViewDto>> GetAll(GetAllTaskResourcesInput input);

        Task<GetTaskResourcesForViewDto> GetTaskResourcesForView(int id);

        Task<GetTaskResourcesForEditOutput> GetTaskResourcesForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditTaskResourcesDto input);

        Task Delete(EntityDto input);
    }
}