using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Asd.Hrm.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asd.Hrm.ProjectContractor;
using Asd.Hrm.ProjectContractors.Dtos;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using Twilio.TwiML.Voice;

namespace Asd.Hrm.ProjectContractors
{
    [AbpAuthorize(AppPermissions.Pages_ProjectContractors)]
    public class ProjectContractorsAppService : HrmAppServiceBase, IProjectContractorsAppService
    {
        private readonly IRepository<Asd.Hrm.ProjectContractor.ProjectContractors> _projectContractorsRepository;

        public ProjectContractorsAppService(IRepository<Asd.Hrm.ProjectContractor.ProjectContractors> projectContractorsRepository)
        {
            _projectContractorsRepository = projectContractorsRepository;
        }

        public async Task<PagedResultDto<GetProjectContractorsForViewDto>> GetAll(GetAllProjectContractorsInput input)
        {
            var filteredProjectContractors = _projectContractorsRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Role.Contains(input.Filter) )
                        .WhereIf(!string.IsNullOrWhiteSpace(input.RoleFilter), e => e.Role.ToLower() == input.RoleFilter.ToLower().Trim());
            var query = (from o in filteredProjectContractors
                         select new GetProjectContractorsForViewDto()
                         {
                             ProjectContractors = ObjectMapper.Map<ProjectContractorsDto>(o)
                         });

            var totalCount = await query.CountAsync();

            var projectContractors = await query
                .PageBy(input)
                .ToListAsync();

            return new PagedResultDto<GetProjectContractorsForViewDto>(
                totalCount,
                projectContractors
            );
        }

        public async Task<GetProjectContractorsForViewDto> GetProjectContractorsForView(int id)
        {
            var ProjectContractors = await _projectContractorsRepository.GetAsync(id);

            var output = new GetProjectContractorsForViewDto { ProjectContractors = ObjectMapper.Map<ProjectContractorsDto>(ProjectContractors) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_ProjectContractors_Edit)]
        public async Task<GetProjectContractorsForEditOutput> GetProjectContractorsForEdit(EntityDto input)
        {
            var ProjectContractors = await _projectContractorsRepository.FirstOrDefaultAsync(input.Id);
            var ProjectContractorsDto = new CreateOrEditProjectContractorsDto()
            {
                Id = ProjectContractors.Id,
                ProjectID = ProjectContractors.ProjectID,
                ContractorID = ProjectContractors.ContractorID,
                Role = ProjectContractors.Role,
            };

            var output = new GetProjectContractorsForEditOutput() { ProjectContractors = ProjectContractorsDto };
            return output;
        }

        public async System.Threading.Tasks.Task CreateOrEdit(CreateOrEditProjectContractorsDto input)
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

        [AbpAuthorize(AppPermissions.Pages_ProjectContractors_Create)]
        public async System.Threading.Tasks.Task Create(CreateOrEditProjectContractorsDto input)
        {
            try
            {
                var projectContractors = ObjectMapper.Map<Asd.Hrm.ProjectContractor.ProjectContractors>(input);
                await _projectContractorsRepository.InsertAsync(projectContractors);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [AbpAuthorize(AppPermissions.Pages_ProjectContractors_Edit)]
        public async System.Threading.Tasks.Task Update(CreateOrEditProjectContractorsDto input)
        {
            var projectContractors = await _projectContractorsRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, projectContractors);
        }

        [AbpAuthorize(AppPermissions.Pages_ProjectContractors_Delete)]
        public async System.Threading.Tasks.Task Delete(EntityDto input)
        {
            await _projectContractorsRepository.DeleteAsync(input.Id);
        }
    }
}