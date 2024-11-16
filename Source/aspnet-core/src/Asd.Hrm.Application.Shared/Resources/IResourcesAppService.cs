using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Asd.Hrm.Resources.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asd.Hrm.Resources
{
    public interface IResourcesAppService : IApplicationService
    {
        Task<PagedResultDto<GetResourcesForViewDto>> GetAll(GetAllResourcesInput input);

        Task<GetResourcesForViewDto> GetResourcesForView(int id);

        Task<GetResourcesForEditOutput> GetResourcesForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditResourcesDto input);

        Task Delete(EntityDto input);
    }
}
