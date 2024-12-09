using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asd.Hrm.Tasks.TaskResource.Dtos
{
    public class TaskResourcesDto : Entity
    {
        public virtual int TaskID { set; get; }
        public virtual int ResourceID { set; get; }
        public virtual decimal ResourceQuantity { set; get; }
    }
}
