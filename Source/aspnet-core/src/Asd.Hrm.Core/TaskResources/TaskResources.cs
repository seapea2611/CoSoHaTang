using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asd.Hrm.TaskResource
{
    [Table("TaskResources")]
    public class TaskResources: Entity
    {
        public virtual int TaskID { get; set; }
        public virtual int ResourceID { get; set; }
        public virtual decimal? ResourceQuantity { get; set; }
    }
}
