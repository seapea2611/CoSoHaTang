using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asd.Hrm.Contractors.Dtos
{
    public class ContractorsDto : EntityDto
    {
        public virtual string ContractorName { get; set; }
        public virtual string Phone { get; set; }
        public virtual string EmailContractor { get; set; }
        public virtual string Specialization { get; set; }
    }
}
