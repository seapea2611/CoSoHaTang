using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asd.Hrm.ProjectContractors.Dtos
{
    public class CreateOrEditProjectContractorsDto : EntityDto<int?>
    {
        public int ProjectContractorsID { get; set; }
        public int ProjectID { get; set; }
        public int ContractorID { get; set; }
    }
}
