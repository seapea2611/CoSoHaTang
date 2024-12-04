using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asd.Hrm.Projects.Dtos
{
    public class GetAllProjectsInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public virtual string ProjectNameFilter { set; get; }
    }
}
