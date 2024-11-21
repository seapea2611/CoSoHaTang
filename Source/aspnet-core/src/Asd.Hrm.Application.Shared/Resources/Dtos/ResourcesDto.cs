using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asd.Hrm.Resources.Dtos
{
    public class ResourcesDto : EntityDto
    {
        public virtual int ResourceID { get; set; }
        public virtual string ResourceType { get; set; }
        public virtual decimal? UnitCost { get; set; }
        public virtual string UnitType { get; set; }
        public virtual string Supplier { get; set; }
    }
}