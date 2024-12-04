using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Asd.Hrm.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asd.Hrm.Contractor;
using Asd.Hrm.Contractors.Dtos;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Asd.Hrm.Contractors
{ 
    [AbpAuthorize(AppPermissions.Pages_Contractors)]
    public class ContractorsAppService : HrmAppServiceBase, IContractorsAppService
    {
        private readonly IRepository<Asd.Hrm.Contractor.Contractors> _contractorsRepository;

        public ContractorsAppService(IRepository<Asd.Hrm.Contractor.Contractors> contractorsRepository)
        {
            _contractorsRepository = contractorsRepository;
        }

        public async Task<PagedResultDto<GetContractorsForViewDto>> GetAll(GetAllContractorsInput input)
        {
            var filteredContractors = _contractorsRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.ContractorName.Contains(input.Filter) || e.Phone.Contains(input.Filter) || e.EmailContractor.Contains(input.Filter) || e.Specialization.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ContractorNameFilter), e => e.ContractorName.ToLower() == input.ContractorNameFilter.ToLower().Trim())
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PhoneFilter), e => e.Phone.ToLower() == input.PhoneFilter.ToLower().Trim())
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EmailContractorFilter), e => e.EmailContractor.ToLower() == input.EmailContractorFilter.ToLower().Trim())
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SpecializationFilter), e => e.Specialization.ToLower() == input.SpecializationFilter.ToLower().Trim());

            var query = (from o in filteredContractors
                         select new GetContractorsForViewDto()
                         {
                             Contractors = ObjectMapper.Map<ContractorsDto>(o)
                         });

            var totalCount = await query.CountAsync();

            var resources = await query
                .PageBy(input)
                .ToListAsync();

            return new PagedResultDto<GetContractorsForViewDto>(
                totalCount,
                resources
            );
        }

        public async Task<GetContractorsForViewDto> GetContractorsForView(int id)
        {
            var Contractors = await _contractorsRepository.GetAsync(id);

            var output = new GetContractorsForViewDto { Contractors = ObjectMapper.Map<ContractorsDto>(Contractors) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_Contractors_Edit)]
        public async Task<GetContractorsForEditOutput> GetContractorsForEdit(EntityDto input)
        {
            var Contractors = await _contractorsRepository.FirstOrDefaultAsync(input.Id);
            var ContractorsDto = new CreateOrEditContractorsDto()
            {
                Id = Contractors.Id,
                ContractorName = Contractors.ContractorName,
                Phone = Contractors.Phone,
                EmailContractor = Contractors.EmailContractor,
                Specialization = Contractors.Specialization,
            };

            var output = new GetContractorsForEditOutput() { Contractors = ContractorsDto };
            return output;
        }

        public async System.Threading.Tasks.Task CreateOrEdit(CreateOrEditContractorsDto input)
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

        [AbpAuthorize(AppPermissions.Pages_Contractors_Create)]
        public async System.Threading.Tasks.Task Create(CreateOrEditContractorsDto input)
        {
            try
            {
                var contractors = ObjectMapper.Map<Asd.Hrm.Contractor.Contractors>(input);
                await _contractorsRepository.InsertAsync(contractors);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [AbpAuthorize(AppPermissions.Pages_Contractors_Edit)]
        public async System.Threading.Tasks.Task Update(CreateOrEditContractorsDto input)
        {
            var contractors = await _contractorsRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, contractors);
        }

        [AbpAuthorize(AppPermissions.Pages_Contractors_Delete)]
        public async System.Threading.Tasks.Task Delete(EntityDto input)
        {
            await _contractorsRepository.DeleteAsync(input.Id);
        }
    }
}
