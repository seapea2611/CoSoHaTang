﻿using Asd.Hrm.MultiTenancy.Payments;

namespace Asd.Hrm.Web.Models.Payment
{
    public class CancelPaymentModel
    {
        public string PaymentId { get; set; }

        public SubscriptionPaymentGatewayType Gateway { get; set; }
    }
}