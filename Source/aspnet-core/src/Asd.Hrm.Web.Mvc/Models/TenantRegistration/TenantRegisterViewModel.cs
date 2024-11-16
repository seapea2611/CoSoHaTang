using Asd.Hrm.Editions;
using Asd.Hrm.Editions.Dto;
using Asd.Hrm.MultiTenancy.Payments;
using Asd.Hrm.Security;
using Asd.Hrm.MultiTenancy.Payments.Dto;

namespace Asd.Hrm.Web.Models.TenantRegistration
{
    public class TenantRegisterViewModel
    {
        public PasswordComplexitySetting PasswordComplexitySetting { get; set; }

        public int? EditionId { get; set; }

        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }
    }
}
