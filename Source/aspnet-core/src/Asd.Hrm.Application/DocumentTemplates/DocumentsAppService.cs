using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Asd.Hrm.Authorization;
using Asd.Hrm.DocumentTemplates.Dtos;
using Asd.Hrm.DocumentTemplates.TaiLieu;
using Asd.Hrm.DocumentTemplates.TaiLieu.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asd.Hrm.DocumentTemplates
{
    [AbpAuthorize(AppPermissions.Pages_DocumentTemplates)]
    public class DocumentsAppService : HrmAppServiceBase, IDocumentsAppService
    {
        private readonly IRepository<Documents> _documentsRepository;

        public DocumentsAppService(IRepository<Documents> documentTemplatesRepository)
        {
            _documentsRepository = documentTemplatesRepository;
        }

        public async Task<GetDocumentsForViewDto> GetDocumentTemplatesForView(int id)
        {
            var DocumentTemplates = await _documentsRepository.GetAsync(id);

            var output = new GetDocumentsForViewDto { DocumentTemplates = ObjectMapper.Map<DocumentsDto>(DocumentTemplates) };

            return output;
        }

        public async System.Threading.Tasks.Task CreateOrEdit(CreateOrEditDocumentsDto input)
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

        [AbpAuthorize(AppPermissions.Pages_DocumentTemplates_Create)]
        public async System.Threading.Tasks.Task Create(CreateOrEditDocumentsDto input)
        {
            try
            {
                var documentTemplates = ObjectMapper.Map<Documents>(input);
                await _documentsRepository.InsertAsync(documentTemplates);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [AbpAuthorize(AppPermissions.Pages_DocumentTemplates_Edit)]
        public async System.Threading.Tasks.Task Update(CreateOrEditDocumentsDto input)
        {
            var documentTemplates = await _documentsRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, documentTemplates);
        }

        [AbpAuthorize(AppPermissions.Pages_DocumentTemplates_Delete)]
        public async System.Threading.Tasks.Task Delete(EntityDto input)
        {
            await _documentsRepository.DeleteAsync(input.Id);
        }
    }
}
