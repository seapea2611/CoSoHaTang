using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asd.Hrm.TasksModel
{
    [Table("TaskResources")]
    public class TaskResources : Entity
    {
        public virtual int TaskID { set; get; }
        public virtual int ResourceID { set; get; }
        public virtual decimal ResourceQuantity { set; get; }
    }
}
