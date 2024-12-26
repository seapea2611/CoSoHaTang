using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asd.Hrm.TaskResources.Dtos
{
    public class TaskResourcesDto : EntityDto
    {
        public virtual int TaskID { get; set; }
        public virtual int ResourceID { get; set; }
        public virtual decimal? ResourceQuantity { get; set; }
    }
}