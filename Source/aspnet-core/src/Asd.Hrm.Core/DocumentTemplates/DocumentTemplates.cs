using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asd.Hrm.DocumentTemplates
{
    [Table("DocumentTemplates")]
    public class DocumentTemplates : Entity
    {
        public virtual string TemplateName { get; set; }
        public virtual string AttachedFileLink { get; set; }
        public virtual string AttachedFileName { get; set; }
        public virtual Byte[] AttachedFile { get; set; }
    }
}
