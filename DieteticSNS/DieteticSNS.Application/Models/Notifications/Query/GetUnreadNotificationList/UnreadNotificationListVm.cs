using System.Collections.Generic;

namespace DieteticSNS.Application.Models.Notifications.Queries.GetUnreadNotificationList
{
    public class UnreadNotificationListVm
    {
        public IList<UnreadNotificationDto> Notifications { get; set; } = new List<UnreadNotificationDto>();
    }
}
