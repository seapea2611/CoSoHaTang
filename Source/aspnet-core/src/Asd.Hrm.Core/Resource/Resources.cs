using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asd.Hrm.Resource
{
    [Table("Resources")]
    public class Resources : Entity
    {
        public virtual int ResourceID { get; set; }
        public virtual string ResourceType { get; set; }
        public virtual decimal? UnitCost { get; set; }
        public virtual string UnitType { get; set;}
        public virtual string Supplier { get; set;}
    }
}
