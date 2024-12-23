using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Asd.Hrm.Job.Dtos;
using Asd.Hrm.Tasks.TaskDocument.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asd.Hrm.Tasks.TaskDocument
{
    public interface ITasksDocumentAppService
    {

        Task<PagedResultDto<GetTasksDocumentForViewDto>> GetTasksDocumentForView(int id);

        Task CreateOrEdit(CreateOrEditTasksDocumentDto input);

        Task Delete(Entity input);
    }
}
