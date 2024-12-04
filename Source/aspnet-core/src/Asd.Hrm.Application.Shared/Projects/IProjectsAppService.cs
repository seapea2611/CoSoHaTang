using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Asd.Hrm.Projects.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asd.Hrm.Projects
{
    public interface IProjectsAppService : IApplicationService
    {
        Task<PagedResultDto<GetProjectsForViewDto>> GetAll(GetAllProjectsInput input);

        Task<GetProjectsForViewDto> GetProjectsForView(int id);

        Task<GetProjectsForEditOutput> GetProjectsForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditProjectsDto input);

        Task Delete(EntityDto input);
    }
}
