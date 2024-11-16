using System.Threading.Tasks;
using Abp.Application.Services;
using Asd.Hrm.MultiTenancy.Payments.Dto;
using Asd.Hrm.MultiTenancy.Payments.Stripe.Dto;

namespace Asd.Hrm.MultiTenancy.Payments.Stripe
{
    public interface IStripePaymentAppService : IApplicationService
    {
        Task ConfirmPayment(StripeConfirmPaymentInput input);

        StripeConfigurationDto GetConfiguration();

        Task<SubscriptionPaymentDto> GetPaymentAsync(StripeGetPaymentInput input);

        Task<string> CreatePaymentSession(StripeCreatePaymentSessionInput input);
    }
}