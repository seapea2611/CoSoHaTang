using Abp.AutoMapper;
using Asd.Hrm.Authorization.Roles.Dto;
using Asd.Hrm.Web.Areas.App.Models.Common;

namespace Asd.Hrm.Web.Areas.App.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class CreateOrEditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool IsEditMode => Role.Id.HasValue;
    }
}