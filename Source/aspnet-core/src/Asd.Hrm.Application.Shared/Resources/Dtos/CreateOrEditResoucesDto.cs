using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asd.Hrm.Resources.Dtos
{
    public class CreateOrEditResourcesDto : EntityDto<int?>
    {
        public int ResourceID { get; set; }
        public string ResourceType { get; set; }
        public decimal? UnitCost { get; set; }
        public string UnitType { get; set; }
        public string Supplier { get; set; }
    }
}