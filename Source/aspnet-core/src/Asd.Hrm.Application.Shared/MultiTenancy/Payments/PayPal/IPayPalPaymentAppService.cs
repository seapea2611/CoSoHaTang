using System.Threading.Tasks;
using Abp.Application.Services;
using Asd.Hrm.MultiTenancy.Payments.PayPal.Dto;

namespace Asd.Hrm.MultiTenancy.Payments.PayPal
{
    public interface IPayPalPaymentAppService : IApplicationService
    {
        Task ConfirmPayment(long paymentId, string paypalOrderId);

        PayPalConfigurationDto GetConfiguration();
    }
}
