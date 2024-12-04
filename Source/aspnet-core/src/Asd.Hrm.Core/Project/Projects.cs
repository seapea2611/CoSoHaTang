using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asd.Hrm.Project
{
    [Table("Projects")]
    public class Projects : Entity
    {
        public virtual string ProjectID { set; get; }
        public virtual string ProjectName { set; get;}
        public virtual string Purpose { set; get;}
        public virtual DateTime StartDate { set; get; }
        public virtual DateTime EstimatedEndDate { set; get;}
        public virtual decimal Budget { set; get; }
        public virtual int ResponsibleEmployeeID { set; get; }
        public virtual string Progress { set; get; }
    }
}
