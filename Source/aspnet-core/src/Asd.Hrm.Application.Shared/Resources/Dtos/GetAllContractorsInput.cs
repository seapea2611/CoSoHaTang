using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asd.Hrm.Resources.Dtos
{
    public class GetAllContractorsInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public string ContractorNameFilter { get; set; }
        public string PhoneFilter { get; set; }
        public string EmailFilter { get; set; }
        public string SpecializationFilter { get; set; }
    }
}
