using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asd.Hrm.Projects.Dtos
{
    public class GetAllProjectsInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public virtual int ProjectIDFilter { set; get; }
        public virtual string ProjectNameFilter { set; get; }
        public virtual int ResponsibleEmployeeIDFilter { set; get; }
        public virtual string ProgressFilter { set; get; }
    }
}
