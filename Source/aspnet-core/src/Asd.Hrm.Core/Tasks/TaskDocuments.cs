using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asd.Hrm.Tasks
{
    [Table("TaskDocuments")]
    public class TaskDocuments : Entity
    {
        public virtual int TaskID { get; set; }
        public virtual int DocumentID { get; set;}
    }
}
