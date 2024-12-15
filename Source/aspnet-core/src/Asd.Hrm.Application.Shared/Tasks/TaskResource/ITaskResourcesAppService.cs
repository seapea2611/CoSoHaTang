using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Asd.Hrm.Job.TaskResource.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asd.Hrm.Job.TaskResource
{
    public interface ITaskResourcesAppService : IApplicationService
    {
        Task<PagedResultDto<GetTaskResourcesForViewDto>> GetAll(GetAllTasksResourcesInput input);

        Task<GetTaskResourcesForViewDto> GetTaskResourcesForView(int id);

        Task<GetTaskResourcesForEditOutput> GetTaskResourcesForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditTaskResourcesDto input);

        Task Delete(EntityDto input);
    }
}
