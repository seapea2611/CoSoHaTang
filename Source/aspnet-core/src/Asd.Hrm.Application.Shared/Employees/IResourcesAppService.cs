using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Asd.Hrm.Employees.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asd.Hrm.Employees
{
    public interface IEmployeesAppService : IApplicationService
    {
        Task<PagedResultDto<GetEmployeesForViewDto>> GetAll(GetAllEmployeesInput input);

        Task<GetEmployeesForViewDto> GetEmployeesForView(int id);

        Task<GetEmployeesForEditOutput> GetEmployeesForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditEmployeesDto input);

        Task Delete(EntityDto input);
    }
}
