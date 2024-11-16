using Abp.AutoMapper;
using Asd.Hrm.Organizations.Dto;

namespace Asd.Hrm.Models.Users
{
    [AutoMapFrom(typeof(OrganizationUnitDto))]
    public class OrganizationUnitModel : OrganizationUnitDto
    {
        public bool IsAssigned { get; set; }
    }
}