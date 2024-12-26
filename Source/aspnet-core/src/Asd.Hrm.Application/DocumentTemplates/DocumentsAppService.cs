using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Asd.Hrm.Authorization;
using Asd.Hrm.DocumentTemplates.Dtos;
using Asd.Hrm.DocumentTemplates.TaiLieu;
using Asd.Hrm.DocumentTemplates.TaiLieu.Dtos;
using Asd.Hrm.Job.Dtos;
using Asd.Hrm.Project;
using Asd.Hrm.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<PagedResultDto<GetDocumentsForViewDto>> GetDocumentTemplatesForView(int id)
        {
            var filter = _documentsRepository.GetAll()
                                                .Where(task => task.TaskID == id);
            GetAllDocumentsInput documentsInput = new GetAllDocumentsInput();

            var query = (from o in filter
                         select new GetDocumentsForViewDto()
                         {
                             DocumentTemplates = ObjectMapper.Map<DocumentsDto>(o)
                         });

            var totalCount = await query.CountAsync();

            var resources = await query
                .PageBy(documentsInput)
                .ToListAsync();

            return new PagedResultDto<GetDocumentsForViewDto>(
                totalCount,
                resources
            );


        }

        public async System.Threading.Tasks.Task CreateOrEdit(CreateOrEditDocumentsDto input, int taskId)
        {
            if (input.Id == null)
            {
                await Create(input, taskId);
            }
            else
            {
                await Update(input, taskId);
            }
        }

        [AbpAuthorize(AppPermissions.Pages_DocumentTemplates_Create)]
        public async System.Threading.Tasks.Task Create(CreateOrEditDocumentsDto input, int t)
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
        public async System.Threading.Tasks.Task Update(CreateOrEditDocumentsDto input, int t)
        {
            var documentTemplates = await _documentsRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, documentTemplates);
        }

        [AbpAuthorize(AppPermissions.Pages_DocumentTemplates_Delete)]
        public async System.Threading.Tasks.Task Delete(EntityDto input)
        {
            await _documentsRepository.DeleteAsync(input.Id);
        }

        public async Task<GetDocumentsForViewDto> GetDocumentsByLink(string link)
        {
            var document = await _documentsRepository.FirstOrDefaultAsync(p => p.Link == link);
            DocumentsDto a = new DocumentsDto();
            a.Id = document.Id;
            a.Link = link;
            a.AttachedFile = document.AttachedFile;
            a.DocumentName = document.DocumentName;
            a.ConfirmationDate = document.ConfirmationDate;
            a.ConfirmingEmployeeID = document.ConfirmingEmployeeID;
            a.TaskID = document.TaskID;

            var output = new GetDocumentsForViewDto { DocumentTemplates = ObjectMapper.Map<DocumentsDto>(a) };


            return output;
        }
    }
}
