using System;

namespace DieteticSNS.Application.Models.Notifications.Queries.GetUnreadNotificationList
{
    public class UnreadNotificationDto
    {
        public int UserId { get; set; }
        public int RecipientId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarPath { get; set; }
    }
}
