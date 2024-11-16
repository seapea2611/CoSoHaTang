using Asd.Hrm.Editions.Dto;

namespace Asd.Hrm.MultiTenancy.Payments.Dto
{
    public class PaymentInfoDto
    {
        public EditionSelectDto Edition { get; set; }

        public decimal AdditionalPrice { get; set; }

        public bool IsLessThanMinimumUpgradePaymentAmount()
        {
            return AdditionalPrice < HrmConsts.MinimumUpgradePaymentAmount;
        }
    }
}
