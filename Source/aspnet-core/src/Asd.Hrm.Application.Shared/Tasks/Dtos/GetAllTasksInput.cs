using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asd.Hrm.Job.Dtos
{
    public class GetAllTasksInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
