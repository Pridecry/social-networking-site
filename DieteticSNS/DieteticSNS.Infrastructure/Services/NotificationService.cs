using System.Threading.Tasks;
using DieteticSNS.Application.Common.Extensions;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Application.Models.Notifications.Queries.GetUnreadNotificationList;
using DieteticSNS.Domain.Enumerations;
using DieteticSNS.Infrastructure.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace DieteticSNS.Infrastructure.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationService(IHubContext<NotificationHub> notificationHub)
        {
            _hubContext = notificationHub;
        }

        public async Task SendNotification(UnreadNotificationDto notification)
        {
            string avatarPath;

            if (notification.AvatarPath == null)
            {
                avatarPath = "/img/noavatar.jpg";
            }
            else
            {
                avatarPath = "/img/uploads/" + notification.AvatarPath;
            }

            var createdAt = notification.CreatedAt.TimeAgo();

            string notificationText = "";

            switch (notification.NotificationType)
            {
                case NotificationType.PostComment:
                    notificationText = "commented on your post."; 
                    break;
                case NotificationType.PostLike:
                    notificationText = "liked your post.";
                    break;
                case NotificationType.CommentLike:
                    notificationText = "liked your comment.";
                    break;
                case NotificationType.UserFollowing:
                    notificationText = "is now following you.";
                    break;
                case NotificationType.UserUnfollowing:
                    notificationText = "stopped following you.";
                    break;
            }

            await _hubContext.Clients.User(notification.RecipientId.ToString()).SendAsync("ReceiveNotification", 
                notification.UserId, 
                createdAt,
                notificationText,
                notification.FirstName, 
                notification.LastName,
                avatarPath);
        }
    }
} 
