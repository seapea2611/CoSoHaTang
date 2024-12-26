using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Entities;
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
    public class TaskDocumentsAppService  : HrmAppServiceBase, ITasksDocumentAppService
    {
        private readonly IRepository<TaskDocuments> _taskdocumentRepository;

        public TaskDocumentsAppService(IRepository<Tasks> tasksRepository, IRepository<Documents> projectRepository, IRepository<TaskDocuments> tasksdocumentRepository)
        {
            _taskdocumentRepository = tasksdocumentRepository;
        }
        public async Task<PagedResultDto<GetTasksDocumentForViewDto>> GetTasksDocumentForView(int taskId)
        {

            var filteredTasks = _taskdocumentRepository.GetAll()
                                .Where(task => task.TaskID == taskId);
            GetAllTasksDocumentInput input = new GetAllTasksDocumentInput();
            var query = (from o in filteredTasks
                         select new GetTasksDocumentForViewDto()
                         {
                             TasksDocument = ObjectMapper.Map<TasksDocumentDto>(o)
                         });

            var totalCount = await query.CountAsync();

            var resources = await query
                .PageBy(input)
                .ToListAsync();

            return new PagedResultDto<GetTasksDocumentForViewDto>(
                totalCount,
                resources
            );
        }

        public async Task CreateOrEdit(CreateOrEditTasksDocumentDto input)
        {
                await Create(input);
        }
        [AbpAuthorize(AppPermissions.Pages_Tasks_Create)]
        public async Task Create(CreateOrEditTasksDocumentDto input)
        {
            try
            {
                var Tasks = ObjectMapper.Map<TaskDocuments>(input);
                await _taskdocumentRepository.InsertAsync(Tasks);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [AbpAuthorize(AppPermissions.Pages_Tasks_Delete)]
        public async Task Delete(Entity input)
        {
            await _taskdocumentRepository.DeleteAsync(input.Id);
        }
    }
}
