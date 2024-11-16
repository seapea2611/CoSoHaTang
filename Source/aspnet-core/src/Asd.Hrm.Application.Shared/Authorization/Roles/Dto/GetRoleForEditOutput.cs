using System.Collections.Generic;
using Asd.Hrm.Authorization.Permissions.Dto;

namespace Asd.Hrm.Authorization.Roles.Dto
{
    public class GetRoleForEditOutput
    {
        public RoleEditDto Role { get; set; }

        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}