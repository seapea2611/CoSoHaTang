/*
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Asd.Hrm.Authorization;
using Asd.Hrm.Projects;
using Asd.Hrm.Projects.Dtos;
using Asd.Hrm.Resources.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asd.Hrm.Project
{
    public class ProjectsAppService : HrmAppServiceBase, IProjectsAppService
    {
        private readonly IRepository<Projects> _projectsRepository;

        public ProjectsAppService(IRepository<Projects> projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }

        public async Task<PagedResultDto<GetProjectsForViewDto>> GetAll(GetAllProjectsInput input)
        {
            var filteredProjects = _projectsRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.UnitType.Contains(input.Filter) || e.ResourceType.Contains(input.Filter) || e.Supplier.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.UnitTypeFilter), e => e.UnitType.ToLower() == input.UnitTypeFilter.ToLower().Trim())
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ResourceTypeFilter), e => e.ResourceType.ToLower() == input.ResourceTypeFilter.ToLower().Trim())
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SupplierFilter), e => e.Supplier.ToLower() == input.SupplierFilter.ToLower().Trim());

            var query = (from o in filteredProjects
                         select new GetProjectsForViewDto()
                         {
                             Projects = ObjectMapper.Map<ProjectsDto>(o)
                         });

            var totalCount = await query.CountAsync();

            var projects = await query
                .PageBy(input)
                .ToListAsync();

            return new PagedResultDto<GetProjectsForViewDto>(
                totalCount,
                projects
            );
        }

        public async Task<GetResourcesForViewDto> GetResourcesForView(int id)
        {
            var Resources = await _resourcesRepository.GetAsync(id);

            var output = new GetResourcesForViewDto { Resources = ObjectMapper.Map<ResourcesDto>(Resources) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_Resources_Edit)]
        public async Task<GetResourcesForEditOutput> GetResourcesForEdit(EntityDto input)
        {
            var Resources = await _resourcesRepository.FirstOrDefaultAsync(input.Id);
            var ResourcesDto = new CreateOrEditResourcesDto()
            {
                Id = Resources.Id,
                ResourceID = Resources.ResourceID,
                ResourceType = Resources.ResourceType,
                UnitCost = Resources.UnitCost,
                UnitType = Resources.UnitType,
                Supplier = Resources.Supplier
            };

            var output = new GetResourcesForEditOutput() { Resources = ResourcesDto };
            return output;
        }

        public async Task CreateOrEdit(CreateOrEditResourcesDto input)
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

        [AbpAuthorize(AppPermissions.Pages_Resources_Create)]
        public async Task Create(CreateOrEditResourcesDto input)
        {
            try
            {
                var resources = ObjectMapper.Map<Asd.Hrm.Resource.Resources>(input);
                await _resourcesRepository.InsertAsync(resources);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [AbpAuthorize(AppPermissions.Pages_Resources_Edit)]
        public async Task Update(CreateOrEditResourcesDto input)
        {
            var resources = await _resourcesRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, resources);
        }

        [AbpAuthorize(AppPermissions.Pages_Resources_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _resourcesRepository.DeleteAsync(input.Id);
        }
    }
}
*/