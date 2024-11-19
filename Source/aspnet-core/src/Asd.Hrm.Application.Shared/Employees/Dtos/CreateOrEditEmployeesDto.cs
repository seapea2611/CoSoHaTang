using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asd.Hrm.Employees.Dtos
{
    public class CreateOrEditEmployeesDto : EntityDto<int?>
    {
        public string EmployeeID { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; }

        public string Role { get; set; }

    }
}
