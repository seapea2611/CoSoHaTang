using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asd.Hrm.Job.TaskResource.Dtos
{
    public class GetAllTasksResourcesInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
