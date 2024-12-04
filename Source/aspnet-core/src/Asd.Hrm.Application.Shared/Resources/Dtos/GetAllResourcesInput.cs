using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asd.Hrm.Resources.Dtos
{
    public class GetAllResourcesInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public string ResourceIDFilter { get; set; }
        public string ResourceTypeFilter { get; set; }
        public string UnitCostFilter { get; set; }
        public string UnitTypeFilter { get; set; }
        public string SupplierFilter { get; set; }
    }
}