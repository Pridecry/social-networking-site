using System;
using DieteticSNS.Domain.Enumerations;

namespace DieteticSNS.Application.Models.Notifications.Queries.GetUnreadNotificationList
{
    public class UnreadNotificationDto
    {
        public int UserId { get; set; }
        public int RecipientId { get; set; }
        public NotificationType NotificationType { get; set; }
        public string NotificationText { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarPath { get; set; }
    }
}
