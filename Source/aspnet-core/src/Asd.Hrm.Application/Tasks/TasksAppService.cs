using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Asd.Hrm.Authorization;
using Asd.Hrm.Project;
using Asd.Hrm.Tasks.Dtos;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asd.Hrm.Tasks
{
    public class TasksAppService : HrmAppServiceBase, ITasksAppService
    {
        private readonly IRepository<Tasks> _tasksRepository;

        public TasksAppService(IRepository<Tasks> tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public async Task<PagedResultDto<GetTasksForViewDto>> GetAll(GetAllTasksInput input)
        {
            var filteredTasks = _tasksRepository.GetAll();

            var query = (from o in filteredTasks
                         select new GetTasksForViewDto()
                         {
                             Tasks = ObjectMapper.Map<TasksDto>(o)
                         });

            var totalCount = await query.CountAsync();

            var resources = await query
                .PageBy(input)
                .ToListAsync();

            return new PagedResultDto<GetTasksForViewDto>(
                totalCount,
                resources
            );
        }

        public async Task<GetTasksForViewDto> GetTasksForView(int id)
        {
            var tasks = await _tasksRepository.GetAsync(id);

            var output = new GetTasksForViewDto { Tasks = ObjectMapper.Map<TasksDto>(tasks) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_Tasks_Edit)]
        public async Task<GetTasksForEditOutput> GetTasksForEdit(EntityDto input)
        {
            var Tasks = await _tasksRepository.FirstOrDefaultAsync(input.Id);
            var TasksDto = new CreateOrEditTasksDto()
            {
                Id = Tasks.Id,
                StartDate = Tasks.StartDate,
                EndDate = Tasks.EndDate,
                TaskDescription = Tasks.TaskDescription,
                EstimatedBudget = Tasks.EstimatedBudget,
                ActualBudget = Tasks.ActualBudget,
                ProjectID = Tasks.ProjectID,
                Stage = Tasks.Stage,
                Status = Tasks.Status,
                ManagerEmployeeID = Tasks.ManagerEmployeeID
            };

            var output = new GetTasksForEditOutput() { Tasks = TasksDto };
            return output;
        }

        public async System.Threading.Tasks.Task CreateOrEdit(CreateOrEditTasksDto input)
        {
            if (input.Id == null)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        [AbpAuthorize(AppPermissions.Pages_Tasks_Create)]
        public async System.Threading.Tasks.Task Create(CreateOrEditTasksDto input)
        {
            try
            {
                var Tasks = ObjectMapper.Map<Tasks>(input);
                await _tasksRepository.InsertAsync(Tasks);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [AbpAuthorize(AppPermissions.Pages_Tasks_Edit)]
        public async System.Threading.Tasks.Task Update(CreateOrEditTasksDto input)
        {
            var Tasks = await _tasksRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, Tasks);
        }

        [AbpAuthorize(AppPermissions.Pages_Tasks_Delete)]
        public async System.Threading.Tasks.Task Delete(EntityDto input)
        {
            await _tasksRepository.DeleteAsync(input.Id);
        }
    }
}
