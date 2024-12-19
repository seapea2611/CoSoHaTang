using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asd.Hrm.DocumentTemplates.TaiLieu.Dtos
{
    public class GetAllDocumentsInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
