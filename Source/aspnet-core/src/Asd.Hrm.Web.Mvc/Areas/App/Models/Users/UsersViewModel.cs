using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Asd.Hrm.Authorization.Permissions.Dto;
using Asd.Hrm.Web.Areas.App.Models.Common;

namespace Asd.Hrm.Web.Areas.App.Models.Users
{
    public class UsersViewModel : IPermissionsEditViewModel
    {
        public string FilterText { get; set; }

        public List<ComboboxItemDto> Roles { get; set; }

        public bool OnlyLockedUsers { get; set; }

        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}
