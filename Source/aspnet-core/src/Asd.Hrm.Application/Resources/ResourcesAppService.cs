using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Asd.Hrm.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asd.Hrm.Resource;
using Asd.Hrm.Resources.Dtos;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Asd.Hrm.Resources
{
    [AbpAuthorize(AppPermissions.Pages_Resources)]
    public class ResourcesAppService : HrmAppServiceBase, IResourcesAppService
    {
        private readonly IRepository<Asd.Hrm.Resource.Resources> _resourcesRepository;

        public ResourcesAppService(IRepository<Asd.Hrm.Resource.Resources> resourcesRepository)
        {
            _resourcesRepository = resourcesRepository;
        }

        public async Task<PagedResultDto<GetResourcesForViewDto>> GetAll(GetAllResourcesInput input)
        {
            var filteredResources = _resourcesRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.UnitType.Contains(input.Filter) || e.ResourceType.Contains(input.Filter) || e.Supplier.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.UnitTypeFilter), e => e.UnitType.ToLower() == input.UnitTypeFilter.ToLower().Trim())
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ResourceTypeFilter), e => e.ResourceType.ToLower() == input.ResourceTypeFilter.ToLower().Trim())
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SupplierFilter), e => e.Supplier.ToLower() == input.SupplierFilter.ToLower().Trim());

            var query = (from o in filteredResources
                         select new GetResourcesForViewDto()
                         {
                             Resources = ObjectMapper.Map<ResourcesDto>(o)
                         });

            var totalCount = await query.CountAsync();

            var resources = await query
                .PageBy(input)
                .ToListAsync();

            return new PagedResultDto<GetResourcesForViewDto>(
                totalCount,
                resources
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
