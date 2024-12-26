using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asd.Hrm.DocumentTemplates.TaiLieu.Dtos
{
    public class DocumentsDto : EntityDto
    {
        public virtual string DocumentName { get; set; }
        public virtual int ConfirmingEmployeeID { get; set; }
        public virtual DateTime ConfirmationDate { get; set; }
        public virtual Byte[] AttachedFile { get; set; }
        public virtual string Link { get; set; }
        public virtual int TaskID { get; set; }
    }
}
