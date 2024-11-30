using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asd.Hrm.Employees.Dtos
{
    public class EmployeesDto : EntityDto
    {
        public virtual string EmployeeID { get; set; }

        public virtual string FullName { get; set; }

        public virtual string Phone { get; set; }

        public virtual string Role { get; set; }
    }
}
