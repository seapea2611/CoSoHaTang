using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asd.Hrm.Tasks.Dtos
{
    public class CreateOrEditTasksDto : EntityDto<int?>
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
    }
}
