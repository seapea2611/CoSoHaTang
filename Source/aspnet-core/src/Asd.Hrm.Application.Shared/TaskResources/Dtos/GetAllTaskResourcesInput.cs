using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asd.Hrm.TaskResources.Dtos
{
    public class GetAllTaskResourcesInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public string TaskIDFilter { get; set; }
        public string ResourceIDFilter { get; set; }
        public string ResourceQuantityFilter { get; set; }
    }
}