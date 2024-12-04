using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Asd.Hrm.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asd.Hrm.DocumentTemplates;
using Asd.Hrm.DocumentTemplates.Dtos;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Asd.Hrm.DocumentTemplates
{
    [AbpAuthorize(AppPermissions.Pages_DocumentTemplates)]
    public class DocumentTemplatesAppService : HrmAppServiceBase, IDocumentTemplatesAppService
    {
        private readonly IRepository<DocumentTemplates> _documentTemplatesRepository;

        public DocumentTemplatesAppService(IRepository<DocumentTemplates> documentTemplatesRepository)
        {
            _documentTemplatesRepository = documentTemplatesRepository;
        }

        public async Task<PagedResultDto<GetDocumentTemplatesForViewDto>> GetAll(GetAllDocumentTemplatesInput input)
        {
            //strings ?
            var filteredDocumentTemplates = _documentTemplatesRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.TemplateName.Contains(input.Filter) || e.AttachedFileLink.Contains(input.Filter) || e.AttachedFileName.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.TemplateNameFilter), e => e.TemplateName.ToLower() == input.TemplateNameFilter.ToLower().Trim())
                        .WhereIf(!string.IsNullOrWhiteSpace(input.AttachedFileLinkFilter), e => e.AttachedFileLink.ToLower() == input.AttachedFileLinkFilter.ToLower().Trim())
                        .WhereIf(!string.IsNullOrWhiteSpace(input.AttachedFileNameFilter), e => e.AttachedFileName.ToLower() == input.AttachedFileNameFilter.ToLower().Trim());

            var query = (from o in filteredDocumentTemplates
                         select new GetDocumentTemplatesForViewDto()
                         {
                             DocumentTemplates = ObjectMapper.Map<DocumentTemplatesDto>(o)
                         });

            var totalCount = await query.CountAsync();

            var documentTemplates = await query
                .PageBy(input)
                .ToListAsync();

            return new PagedResultDto<GetDocumentTemplatesForViewDto>(
                totalCount,
                documentTemplates
            );
        }

        public async Task<GetDocumentTemplatesForViewDto> GetDocumentTemplatesForView(int id)
        {
            var DocumentTemplates = await _documentTemplatesRepository.GetAsync(id);

            var output = new GetDocumentTemplatesForViewDto { DocumentTemplates = ObjectMapper.Map<DocumentTemplatesDto>(DocumentTemplates) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_DocumentTemplates_Edit)]
        public async Task<GetDocumentTemplatesForEditOutput> GetDocumentTemplatesForEdit(EntityDto input)
        {
            var DocumentTemplates = await _documentTemplatesRepository.FirstOrDefaultAsync(input.Id);
            var DocumentTemplatesDto = new CreateOrEditDocumentTemplatesDto()
            {
                Id = DocumentTemplates.Id,
                TemplateName = DocumentTemplates.TemplateName,
                AttachedFileLink = DocumentTemplates.AttachedFileLink,
                AttachedFileName = DocumentTemplates.AttachedFileName,
                AttachedFile = DocumentTemplates.AttachedFile
            };

            var output = new GetDocumentTemplatesForEditOutput() { DocumentTemplates = DocumentTemplatesDto };
            return output;
        }

        public async System.Threading.Tasks.Task CreateOrEdit(CreateOrEditDocumentTemplatesDto input)
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
        public async System.Threading.Tasks.Task Create(CreateOrEditDocumentTemplatesDto input)
        {
            try
            {
                var documentTemplates = ObjectMapper.Map<DocumentTemplates>(input);
                await _documentTemplatesRepository.InsertAsync(documentTemplates);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [AbpAuthorize(AppPermissions.Pages_DocumentTemplates_Edit)]
        public async System.Threading.Tasks.Task Update(CreateOrEditDocumentTemplatesDto input)
        {
            var documentTemplates = await _documentTemplatesRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, documentTemplates);
        }

        [AbpAuthorize(AppPermissions.Pages_DocumentTemplates_Delete)]
        public async System.Threading.Tasks.Task Delete(EntityDto input)
        {
            await _documentTemplatesRepository.DeleteAsync(input.Id);
        }
    }
}
