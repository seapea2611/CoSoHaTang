using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Asd.Hrm.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asd.Hrm.Employees;
using Asd.Hrm.Employees.Dtos;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Asd.Hrm.Employees
{
    [AbpAuthorize(AppPermissions.Pages_Employees)]
    public class EmployeesAppService : HrmAppServiceBase, IEmployeesAppService
    {
        private readonly IRepository<Asd.Hrm.Employee.Employees> _employeesRepository;

        public EmployeesAppService(IRepository<Asd.Hrm.Employee.Employees> employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        public async Task<PagedResultDto<GetEmployeesForViewDto>> GetAll(GetAllEmployeesInput input)
        {
            var filteredEmployees = _employeesRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.FullName.Contains(input.Filter) || e.Phone.Contains(input.Filter) || e.Role.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.FullNameFilter), e => e.FullName.ToLower() == input.FullNameFilter.ToLower().Trim())
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PhoneFilter), e => e.Phone.ToLower() == input.PhoneFilter.ToLower().Trim())
                        .WhereIf(!string.IsNullOrWhiteSpace(input.RoleFilter), e => e.Role.ToLower() == input.RoleFilter.ToLower().Trim());

            var query = (from o in filteredEmployees
                         select new GetEmployeesForViewDto()
                         {
                             Employees = ObjectMapper.Map<EmployeesDto>(o)
                         });

            var totalCount = await query.CountAsync();

            var employees = await query
                .PageBy(input)
                .ToListAsync();

            return new PagedResultDto<GetEmployeesForViewDto>(
                totalCount,
                employees
            );
        }

        public async Task<GetEmployeesForViewDto> GetEmployeesForView(int id)
        {
            var Employees = await _employeesRepository.GetAsync(id);

            var output = new GetEmployeesForViewDto { Employees = ObjectMapper.Map<EmployeesDto>(Employees) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_Employees_Edit)]
        public async Task<GetEmployeesForEditOutput> GetEmployeesForEdit(EntityDto input)
        {
            var Employees = await _employeesRepository.FirstOrDefaultAsync(input.Id);
            var EmployeesDto = new CreateOrEditEmployeesDto()
            {
                Id = Employees.Id,
                EmployeeID = Employees.EmployeeID,
                FullName = Employees.FullName,
                Phone = Employees.Phone,
                Role = Employees.Role,
            };

            var output = new GetEmployeesForEditOutput() { Employees = EmployeesDto };
            return output;
        }

        public async System.Threading.Tasks.Task CreateOrEdit(CreateOrEditEmployeesDto input)
        {
            if (input.Id == null)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        [AbpAuthorize(AppPermissions.Pages_Employees_Create)]
        public async System.Threading.Tasks.Task Create(CreateOrEditEmployeesDto input)
        {
            try
            {
                var employees = ObjectMapper.Map<Asd.Hrm.Employee.Employees>(input);
                await _employeesRepository.InsertAsync(employees);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [AbpAuthorize(AppPermissions.Pages_Employees_Edit)]
        public async System.Threading.Tasks.Task Update(CreateOrEditEmployeesDto input)
        {
            var employees = await _employeesRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, employees);
        }

        [AbpAuthorize(AppPermissions.Pages_Employees_Delete)]
        public async System.Threading.Tasks.Task Delete(EntityDto input)
        {
            await _employeesRepository.DeleteAsync(input.Id);
        }

        public async Task<string> GetEmployeeName(int id)
        {
            var Employees = await _employeesRepository.GetAsync(id);

            return Employees.FullName;
        }
    }
}
