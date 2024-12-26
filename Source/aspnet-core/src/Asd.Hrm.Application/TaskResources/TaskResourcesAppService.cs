using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Asd.Hrm.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asd.Hrm.TaskResources;
using Asd.Hrm.TaskResources.Dtos;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using Twilio.TwiML.Voice;

namespace Asd.Hrm.TaskResources
{
    [AbpAuthorize(AppPermissions.Pages_TaskResources)]
    public class TaskResourcesAppService : HrmAppServiceBase, ITaskResourcesAppService
    {
        private readonly IRepository<Asd.Hrm.TaskResource.TaskResources> _taskResourcesRepository;

        public TaskResourcesAppService(IRepository<Asd.Hrm.TaskResource.TaskResources> taskResourcesRepository)
        {
            _taskResourcesRepository = taskResourcesRepository;
        }

        public async Task<PagedResultDto<GetTaskResourcesForViewDto>> GetAll(GetAllTaskResourcesInput input)
        {
            var filteredTaskResources = _taskResourcesRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.TaskIDFilter), e => e.TaskID.ToString() == input.TaskIDFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ResourceIDFilter), e => e.ResourceID.ToString() == input.ResourceIDFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ResourceQuantityFilter), e => e.ResourceQuantity.ToString() == input.ResourceQuantityFilter);

            var query = (from o in filteredTaskResources
                         select new GetTaskResourcesForViewDto()
                         {
                             TaskResources = ObjectMapper.Map<TaskResourcesDto>(o)
                         });

            var totalCount = await query.CountAsync();

            var taskResources = await query
                .PageBy(input)
                .ToListAsync();

            return new PagedResultDto<GetTaskResourcesForViewDto>(
                totalCount,
                taskResources
            );
        }

        public async Task<GetTaskResourcesForViewDto> GetTaskResourcesForView(int id)
        {
            var taskResources = await _taskResourcesRepository.GetAsync(id);

            var output = new GetTaskResourcesForViewDto { TaskResources = ObjectMapper.Map<TaskResourcesDto>(taskResources) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_TaskResources_Edit)]
        public async Task<GetTaskResourcesForEditOutput> GetTaskResourcesForEdit(EntityDto input)
        {
            var taskResources = await _taskResourcesRepository.FirstOrDefaultAsync(input.Id);

            var taskResourcesDto = new CreateOrEditTaskResourcesDto()
            {
                Id = taskResources.Id,
                TaskID = taskResources.TaskID,
                ResourceID = taskResources.ResourceID,
                ResourceQuantity = taskResources.ResourceQuantity
            };

            var output = new GetTaskResourcesForEditOutput() { TaskResources = taskResourcesDto };
            return output;
        }

        public async System.Threading.Tasks.Task CreateOrEdit(CreateOrEditTaskResourcesDto input)
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

        [AbpAuthorize(AppPermissions.Pages_TaskResources_Create)]
        public async System.Threading.Tasks.Task Create(CreateOrEditTaskResourcesDto input)
        {
            try
            {
                var taskResources = ObjectMapper.Map<Asd.Hrm.TaskResource.TaskResources>(input);
                await _taskResourcesRepository.InsertAsync(taskResources);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [AbpAuthorize(AppPermissions.Pages_TaskResources_Edit)]
        public async System.Threading.Tasks.Task Update(CreateOrEditTaskResourcesDto input)
        {
            var taskResources = await _taskResourcesRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, taskResources);
        }

        [AbpAuthorize(AppPermissions.Pages_TaskResources_Delete)]
        public async System.Threading.Tasks.Task Delete(EntityDto input)
        {
            await _taskResourcesRepository.DeleteAsync(input.Id);
        }
    }
}