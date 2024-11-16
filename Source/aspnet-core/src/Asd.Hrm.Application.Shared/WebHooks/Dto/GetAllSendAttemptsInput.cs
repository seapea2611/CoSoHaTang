using Asd.Hrm.Dto;

namespace Asd.Hrm.WebHooks.Dto
{
    public class GetAllSendAttemptsInput : PagedInputDto
    {
        public string SubscriptionId { get; set; }
    }
}
