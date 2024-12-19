using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Asd.Hrm.Authorization;
using Asd.Hrm.DocumentTemplates;
using Asd.Hrm.Job.Dtos;
using Asd.Hrm.Tasks;
using Asd.Hrm.Tasks.TaskDocument;
using Asd.Hrm.Tasks.TaskDocument.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asd.Hrm.Job
{
    [AbpAuthorize(AppPermissions.Pages_Tasks)]
    public class TaskDocumentsAppService : HrmAppServiceBase, ITasksDocumentAppService
    {
        private readonly IRepository<Tasks> _tasksRepository;
        private readonly IRepository<Documents> _documentRepository;
        private readonly IRepository<TaskDocuments> _taskdocumentRepository;

        public TaskDocumentsAppService(IRepository<Tasks> tasksRepository, IRepository<Documents> projectRepository, IRepository<TaskDocuments> a)
        {
            _tasksRepository = tasksRepository;
            _documentRepository = projectRepository;
            _taskdocumentRepository = a;
        }
        public async Task<PagedResultDto<GetTasksForViewDto>> GetTasksDocumentForView(int taskId, int documentId)
        {

            var filteredTasks = _tasksRepository.GetAll()
                                                .Where(task => task.Id == taskId);
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

        public async Task CreateOrEdit(CreateOrEditTasksDocumentDto input)
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
        public async System.Threading.Tasks.Task Create(CreateOrEditTasksDocumentDto input)
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
        public async Task Update(CreateOrEditTasksDocumentDto input)
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
