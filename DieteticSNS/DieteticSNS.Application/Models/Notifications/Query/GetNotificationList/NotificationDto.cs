using System;

namespace DieteticSNS.Application.Models.Notifications.Queries.GetNotificationList
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarPath { get; set; }
    }
}
