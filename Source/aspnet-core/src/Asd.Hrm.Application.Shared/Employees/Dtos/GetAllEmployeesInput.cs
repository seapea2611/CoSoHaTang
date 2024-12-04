using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asd.Hrm.Employees.Dtos
{
    public class GetAllEmployeesInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public string EmployeeIDFilter { get; set; }
        public string FullNameFilter { get; set; }
        public string PhoneFilter { get; set; }
        public string RoleFilter { get; set; }
    }
}
