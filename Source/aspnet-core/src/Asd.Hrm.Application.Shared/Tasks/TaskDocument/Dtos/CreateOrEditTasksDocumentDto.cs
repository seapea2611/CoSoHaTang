﻿using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asd.Hrm.Tasks.TaskDocument.Dtos
{
    public class CreateOrEditTasksDocumentDto : EntityDto<int?>
    {
        public virtual int TaskID { get; set; }
        public virtual int DocumentID { get; set; }
    }
}
