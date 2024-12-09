using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asd.Hrm.Contractors.Dtos
{
    public class CreateOrEditContractorsDto : EntityDto<int?>
    {
        public string ContractorName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Specialization { get; set; }
    }
}
