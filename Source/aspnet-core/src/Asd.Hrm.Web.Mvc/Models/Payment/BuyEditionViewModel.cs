using System.Collections.Generic;
using Asd.Hrm.Editions;
using Asd.Hrm.Editions.Dto;
using Asd.Hrm.MultiTenancy.Payments;
using Asd.Hrm.MultiTenancy.Payments.Dto;

namespace Asd.Hrm.Web.Models.Payment
{
    public class BuyEditionViewModel
    {
        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public decimal? AdditionalPrice { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}
