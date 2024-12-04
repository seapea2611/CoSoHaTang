using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asd.Hrm.DocumentTemplates.Dtos
{
    public class DocumentTemplatesDto : EntityDto
    {
        public virtual string TemplateName { get; set; }
        public virtual string AttachedFileLink { get; set; }
        public virtual string AttachedFileName { get; set; }
        public virtual Byte[] AttachedFile { get; set; }
    }
}
