
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Asd.Hrm.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using Asd.Hrm.Projects;
using Asd.Hrm.Projects.Dtos;
using Asd.Hrm.Job;

namespace Asd.Hrm.Project
{
    [AbpAuthorize(AppPermissions.Pages_Projects)]
    public class ProjectsAppService : HrmAppServiceBase, IProjectsAppService
    {
        private readonly IRepository<Projects> _projectsRepository;
        private readonly IRepository<Asd.Hrm.Job.Tasks> _tasksRepository;


        public ProjectsAppService(IRepository<Projects> projectsRepository, IRepository<Job.Tasks> tasksRepository)
        {
            _projectsRepository = projectsRepository;
            _tasksRepository = tasksRepository;
        }

        public async Task<PagedResultDto<GetProjectsForViewDto>> GetAll(GetAllProjectsInput input)
        {
            var filteredResources = _projectsRepository.GetAll()
                                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.ProjectName.Contains(input.Filter))
                                        .WhereIf(!string.IsNullOrWhiteSpace(input.ProjectNameFilter), e => e.ProjectName.ToLower() == input.ProjectNameFilter.ToLower().Trim());

            var query = (from o in filteredResources
                         select new GetProjectsForViewDto()
                         {
                             Projects = ObjectMapper.Map<ProjectsDto>(o)
                         });

            var totalCount = await query.CountAsync();

            var resources = await query
                .PageBy(input)
                .ToListAsync();

            return new PagedResultDto<GetProjectsForViewDto>(
                totalCount,
                resources
            );
        }

        public async Task<GetProjectsForViewDto> GetProjectsForView(int id)
        {
            var Projects = await _projectsRepository.GetAsync(id);

            var output = new GetProjectsForViewDto { Projects = ObjectMapper.Map<ProjectsDto>(Projects) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_Projects_Edit)]
        public async Task<GetProjectsForEditOutput> GetProjectsForEdit(EntityDto input)
        {
            var Projects = await _projectsRepository.FirstOrDefaultAsync(input.Id);
            var ProjectsDto = new CreateOrEditProjectsDto()
            {
                Id = Projects.Id,
                ProjectID = Projects.ProjectID,
                ProjectName = Projects.ProjectName,
                Purpose = Projects.Purpose,
                StartDate = Projects.StartDate,
                EstimatedEndDate = Projects.EstimatedEndDate,
                Budget = Projects.Budget,
                ResponsibleEmployeeID = Projects.ResponsibleEmployeeID,
                Progress = Projects.Progress
            };

            var output = new GetProjectsForEditOutput() { Projects = ProjectsDto };
            return output;
        }

        public async System.Threading.Tasks.Task CreateOrEdit(CreateOrEditProjectsDto input)
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

        [AbpAuthorize(AppPermissions.Pages_Projects_Create)]
        public async System.Threading.Tasks.Task Create(CreateOrEditProjectsDto input)
        {
            try
            {
                var projects = ObjectMapper.Map<Projects>(input);
                await _projectsRepository.InsertAsync(projects);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [AbpAuthorize(AppPermissions.Pages_Projects_Edit)]
        public async System.Threading.Tasks.Task Update(CreateOrEditProjectsDto input)
        {
            var projects = await _projectsRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, projects);
        }

        [AbpAuthorize(AppPermissions.Pages_Projects_Delete)]
        public async System.Threading.Tasks.Task Delete(EntityDto input)
        {
            await _projectsRepository.DeleteAsync(input.Id);
        }

        public async Task<int> GetProjectId(string name)
        {

            var filteredProjects = _projectsRepository.GetAll();
            var projectIdQuery = from project in filteredProjects
                                  where project.ProjectName == name
                                  select project.Id;
            int projectId = projectIdQuery.FirstOrDefault();
            return projectId;
        }

        public async Task<string> GetProjectName(int id)
        {
            var filteredProjects = _projectsRepository.GetAll();
            var projectIdQuery = from employee in filteredProjects
                                 where employee.Id == id
                                  select employee.ProjectName;
            string projectName = projectIdQuery.FirstOrDefault();
            return projectName;
        }

        public async Task<decimal> GeBudget(int projectId)
        {
            decimal budget = 0;

            var tasks = await _tasksRepository.GetAll()
                .Where(t => t.ProjectID == projectId)
                .AsTracking() 
                .ToListAsync();
            budget = tasks.Sum(t => t.ActualBudget);

            return budget;
        }
    }
}
