using Abp.Authorization;
using Asd.Hrm.Authorization.Roles;
using Asd.Hrm.Authorization.Users;

namespace Asd.Hrm.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
