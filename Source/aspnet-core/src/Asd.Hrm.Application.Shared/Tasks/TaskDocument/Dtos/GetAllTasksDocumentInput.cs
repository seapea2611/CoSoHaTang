using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asd.Hrm.Tasks.TaskDocument.Dtos
{
    public class GetAllTasksDocumentInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

    }
}
