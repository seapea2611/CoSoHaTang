using System.Collections.Generic;
using Asd.Hrm.Authorization.Permissions.Dto;

namespace Asd.Hrm.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}