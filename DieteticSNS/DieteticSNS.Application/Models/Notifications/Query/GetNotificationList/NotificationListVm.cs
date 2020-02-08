using System.Collections.Generic;

namespace DieteticSNS.Application.Models.Notifications.Queries.GetNotificationList
{
    public class NotificationListVm
    {
        public IList<NotificationDto> Notifications { get; set; } = new List<NotificationDto>();
    }
}
