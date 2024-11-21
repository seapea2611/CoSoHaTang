using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asd.Hrm.Contractors.Dtos
{
    public class GetAllContractorsInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public string ContractorNameFilter { get; set; }
        public string PhoneFilter { get; set; }
        public string EmailContractorFilter { get; set; }
        public string SpecializationFilter { get; set; }
    }
}
