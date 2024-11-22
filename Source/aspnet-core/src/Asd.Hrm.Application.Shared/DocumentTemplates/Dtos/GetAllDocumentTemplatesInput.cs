using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asd.Hrm.DocumentTemplates.Dtos
{
    public class GetAllDocumentTemplatesInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public string TemplateNameFilter { get; set; }
        public string AttachedFileLinkFilter { get; set; }
        public string AttachedFileNameFilter { get; set; }
        public Byte[] AttachedFileFilter { get; set; }
    }
}