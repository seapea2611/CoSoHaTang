using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Asd.Hrm.DocumentTemplates.TaiLieu.Dtos;
using Asd.Hrm.Job.Dtos;
using Asd.Hrm.Tasks.TaskDocument.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asd.Hrm.Job
{
    public interface ITasksAppService : IApplicationService
    {
        Task<PagedResultDto<GetTasksForViewDto>> GetAll(GetAllTasksInput input);

        Task<PagedResultDto<GetTasksForViewDto>> GetTasksForView(int projectId);

        Task<GetTasksForEditOutput> GetTasksForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditTasksDto input);

        Task Delete(EntityDto input);
        Task UpdateProjectProgress(int projectId);
        Task<bool> CheckBeforeSave(int projectId, string stage);
    }
}
