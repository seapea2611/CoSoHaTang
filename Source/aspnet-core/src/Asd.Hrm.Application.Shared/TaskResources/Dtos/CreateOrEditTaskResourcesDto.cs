using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asd.Hrm.TaskResources.Dtos
{
    public class CreateOrEditTaskResourcesDto : EntityDto<int?>
    {
        public int TaskID { get; set; }
        public int ResourceID { get; set; }
        public decimal? ResourceQuantity { get; set; }
    }
}