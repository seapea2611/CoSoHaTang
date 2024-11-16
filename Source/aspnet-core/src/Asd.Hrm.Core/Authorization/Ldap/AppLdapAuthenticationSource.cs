using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using Asd.Hrm.Authorization.Users;
using Asd.Hrm.MultiTenancy;

namespace Asd.Hrm.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}