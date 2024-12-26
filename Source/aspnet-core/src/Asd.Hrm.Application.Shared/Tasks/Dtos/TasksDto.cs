using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asd.Hrm.Job.Dtos
{
    public class TasksDto : EntityDto
    {
        public virtual DateTime StartDate { set; get; }
        public virtual DateTime EndDate { set; get; }
        public virtual string TaskDescription { set; get; }
        public virtual decimal EstimatedBudget { set; get; }
        public virtual decimal ActualBudget { set; get; }
        public virtual int ProjectID { set; get; }
        public virtual string Stage { set; get; }
        public virtual string Status { set; get; }
        public virtual int ManagerEmployeeID { get; set; }
        public virtual int Unwanted { get; set; }
        public virtual DateTime EstimatedStartDate { set; get; }
        public virtual DateTime EstimatedEndDate { set; get; }


    }
}
