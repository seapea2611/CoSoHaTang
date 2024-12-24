using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asd.Hrm.ProjectContractor

{
    [Table("ProjectContractors")]
    public class ProjectContractors : Entity
    {
        public virtual int ProjectID { get; set; }
        public virtual int ContractorID { get; set; }
        public virtual string Role { get; set; }
    }
}
