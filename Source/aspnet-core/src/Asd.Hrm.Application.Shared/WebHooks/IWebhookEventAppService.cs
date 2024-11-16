using System.Threading.Tasks;
using Abp.Webhooks;

namespace Asd.Hrm.WebHooks
{
    public interface IWebhookEventAppService
    {
        Task<WebhookEvent> Get(string id);
    }
}
