using System;
using System.Collections.Generic;
using System.Text;

namespace Asd.Hrm.Projects.Dtos
{
    public class GetProjectsForViewDto
    {
        public ProjectsDto Projects { get; set; }
        public string EmployeeName { set; get; }
    }
}
