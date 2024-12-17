using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Asd.Hrm.Authorization;
using Asd.Hrm.Job.Dtos;
using Asd.Hrm.Project;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Asd.Hrm.Job
{
    [AbpAuthorize(AppPermissions.Pages_Tasks)]
    public class TasksAppService : HrmAppServiceBase, ITasksAppService
    {
        private readonly IRepository<Tasks> _tasksRepository;
        private readonly IRepository<Asd.Hrm.Project.Projects> _projectRepository;

        public TasksAppService(IRepository<Tasks> tasksRepository, IRepository<Asd.Hrm.Project.Projects> projectRepository)
        {
            _tasksRepository = tasksRepository;
            _projectRepository = projectRepository;
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
    public async Task<PagedResultDto<GetTasksForViewDto>> GetTasksForView(int projectId)
        {
            
            var filteredTasks = _tasksRepository.GetAll()
                                                .Where(task => task.ProjectID == projectId);
            GetAllTasksInput input = new GetAllTasksInput();
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

        public async Task CreateOrEdit(CreateOrEditTasksDto input)
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

        public async Task UpdateProjectProgress(int projectId)
        {
            // Lấy tất cả các Task đã được theo dõi, bao gồm cả Task mới tạo
            var tasks = await _tasksRepository.GetAll()
                .Where(t => t.ProjectID == projectId)
                .AsTracking() // Đảm bảo lấy cả dữ liệu chưa lưu
                .ToListAsync();

            // Lấy đối tượng Project
            var project = await _projectRepository.FirstOrDefaultAsync(p => p.Id == projectId);

            if (project == null)
            {
                throw new Exception("Project not found");
            }

            // Áp dụng các điều kiện cập nhật trạng thái Progress
            if (tasks.Any(t => t.Stage == "Chuẩn bị dự án" && t.Status == "Đang thực hiện"))
            {
                project.Progress = "Chuẩn bị dự án";
            }
            else if (
                tasks.Where(t => t.Stage == "Chuẩn bị dự án").All(t => t.Status == "Đã xong") &&
                tasks.Any(t => t.Stage == "Thi công" && t.Status == "Đang thực hiện"))
            {
                project.Progress = "Thi công";
            }
            else if (
                tasks.Where(t => t.Stage == "Chuẩn bị dự án" || t.Stage == "Thi công")
                     .All(t => t.Status == "Đã xong") &&
                tasks.Any(t => t.Stage == "Nghiệm thu bàn giao" && t.Status == "Đang thực hiện"))
            {
                project.Progress = "Nghiệm thu bàn giao";
            }
            else if (tasks.Where(t => t.Stage == "Nghiệm thu bàn giao").All(t => t.Status == "Đã xong"))
            {
                project.Progress = "Hoàn thành";
            }
            else
            {
                project.Progress = "Chờ chuyển giai đoạn";
            }


            // Lưu thay đổi vào cơ sở dữ liệu
            await _projectRepository.UpdateAsync(project);
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
        public async Task Update(CreateOrEditTasksDto input)
        {
            var Tasks = await _tasksRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, Tasks);
        }

        [AbpAuthorize(AppPermissions.Pages_Tasks_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _tasksRepository.DeleteAsync(input.Id);
        }
    }
}
