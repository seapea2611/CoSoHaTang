using System.Collections.Generic;
using Asd.Hrm.Authorization.Permissions.Dto;

namespace Asd.Hrm.Web.Areas.App.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}