using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asd.Hrm.ProjectContractors.Dtos
{
    public class ProjectContractorsDto : EntityDto
    {
        public virtual int ProjectContractorsID { get; set; }
        public virtual int ProjectID { get; set; }
        public virtual int ContractorID { get; set; }
    }
}