using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asd.Hrm.DocumentTemplates.Dtos
{
    public class CreateOrEditDocumentTemplatesDto : EntityDto<int?>
    {
        public string TemplateName { get; set; }
        public string AttachedFileLink { get; set; }
        public string AttachedFileName { get; set; }
        public Byte[] AttachedFile { get; set; }
    }
}
