using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Asd.Hrm.DocumentTemplates.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asd.Hrm.DocumentTemplates
{
    public interface IDocumentTemplatesAppService : IApplicationService
    {
        Task<PagedResultDto<GetDocumentTemplatesForViewDto>> GetAll(GetAllDocumentTemplatesInput input);

        Task<GetDocumentTemplatesForViewDto> GetDocumentTemplatesForView(int id);

        Task<GetDocumentTemplatesForEditOutput> GetDocumentTemplatesForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditDocumentTemplatesDto input);

        Task Delete(EntityDto input);
    }
}