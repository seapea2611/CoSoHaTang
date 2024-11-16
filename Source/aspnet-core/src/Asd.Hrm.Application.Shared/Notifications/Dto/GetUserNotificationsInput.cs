using System;
using Abp.Notifications;
using Asd.Hrm.Dto;

namespace Asd.Hrm.Notifications.Dto
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}