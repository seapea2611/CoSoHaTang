using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asd.Hrm.Projects.Dtos
{
    public class ProjectsDto : EntityDto
    {
        public virtual string ProjectID { set; get; }
        public virtual string ProjectName { set; get; }
        public virtual string Purpose { set; get; }
        public virtual DateTime StartDate { set; get; }
        public virtual DateTime EstimatedEndDate { set; get; }
        public virtual decimal Budget { set; get; }
        public virtual int ResponsibleEmployeeID { set; get; }
        public virtual string Progress { set; get; }
    }
}
