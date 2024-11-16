using System.Threading.Tasks;
using Asd.Hrm.Authorization.Users;

namespace Asd.Hrm.WebHooks
{
    public interface IAppWebhookPublisher
    {
        Task PublishTestWebhook();
    }
}
