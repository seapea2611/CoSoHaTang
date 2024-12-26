using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Asd.Hrm.DocumentTemplates.Dtos;
using Asd.Hrm.DocumentTemplates.TaiLieu.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asd.Hrm.DocumentTemplates.TaiLieu
{
    public interface IDocumentsAppService : IApplicationService
    {
        Task<PagedResultDto<GetDocumentsForViewDto>> GetDocumentTemplatesForView(int id);

        Task CreateOrEdit(CreateOrEditDocumentsDto input, int taskID);

        Task Delete(EntityDto input);
        Task<GetDocumentsForViewDto> GetDocumentsByLink(string link);
        
    }
}
