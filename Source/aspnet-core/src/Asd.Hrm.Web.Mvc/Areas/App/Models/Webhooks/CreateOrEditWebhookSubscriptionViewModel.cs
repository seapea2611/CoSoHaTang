using Abp.Application.Services.Dto;
using Abp.Webhooks;
using Asd.Hrm.WebHooks.Dto;

namespace Asd.Hrm.Web.Areas.App.Models.Webhooks
{
    public class CreateOrEditWebhookSubscriptionViewModel
    {
        public WebhookSubscription WebhookSubscription { get; set; }

        public ListResultDto<GetAllAvailableWebhooksOutput> AvailableWebhookEvents { get; set; }
    }
}
