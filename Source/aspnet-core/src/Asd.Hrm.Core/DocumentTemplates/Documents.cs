using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asd.Hrm.DocumentTemplates
{
    [Table("Documents")]
    public class Documents : Entity
    {
        public virtual string DocumentName { get; set; }
        public virtual int ConfirmingEmployeeID { get; set; }
        public virtual DateTime ConfirmationDate { get; set; }
        public virtual Byte[] AttachedFile { get; set; }
        public virtual string Link { get; set; }

    }
}
