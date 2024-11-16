using Abp.Domain.Services;

namespace Asd.Hrm
{
    public abstract class HrmDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected HrmDomainServiceBase()
        {
            LocalizationSourceName = HrmConsts.LocalizationSourceName;
        }
    }
}
