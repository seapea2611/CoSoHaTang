using Abp.AutoMapper;
using Asd.Hrm.Authorization.Users;
using Asd.Hrm.Authorization.Users.Dto;
using Asd.Hrm.Web.Areas.App.Models.Common;

namespace Asd.Hrm.Web.Areas.App.Models.Users
{
    [AutoMapFrom(typeof(GetUserPermissionsForEditOutput))]
    public class UserPermissionsEditViewModel : GetUserPermissionsForEditOutput, IPermissionsEditViewModel
    {
        public User User { get; set; }
    }
}