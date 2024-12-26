using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asd.Hrm.ProjectContractors.Dtos
{
    public class GetAllProjectContractorsInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public int ProjectIDFilter { get; set; }
        public int ContractorIDFilter { get; set; }
        public string RoleFilter { get; set; }

    }
}