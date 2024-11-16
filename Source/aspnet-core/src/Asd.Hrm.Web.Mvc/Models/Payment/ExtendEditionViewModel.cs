using System.Collections.Generic;
using Asd.Hrm.Editions.Dto;
using Asd.Hrm.MultiTenancy.Payments;

namespace Asd.Hrm.Web.Models.Payment
{
    public class ExtendEditionViewModel
    {
        public EditionSelectDto Edition { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}