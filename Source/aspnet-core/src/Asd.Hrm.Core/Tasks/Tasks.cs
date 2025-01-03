﻿using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asd.Hrm.Job
{
    [Table("Tasks")]
    public class Tasks : Entity
    {
        public virtual DateTime StartDate { set; get; }
        public virtual DateTime EndDate { set; get;}
        public virtual string TaskDescription { set; get; }
        public virtual decimal EstimatedBudget { set; get;}
        public virtual decimal ActualBudget { set; get;}
        public virtual int ProjectID { set; get; }
        public virtual string Stage { set; get;}
        public virtual string Status { set; get; }
        public virtual int ManagerEmployeeID { get; set; }
        public virtual int Unwanted { get; set; }
        public virtual DateTime EstimatedStartDate { set; get; }
        public virtual DateTime EstimatedEndDate { set; get; }

    }
}
