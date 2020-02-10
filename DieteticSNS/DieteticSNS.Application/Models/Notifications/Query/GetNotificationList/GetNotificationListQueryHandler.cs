using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Enumerations;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace DieteticSNS.Application.Models.Notifications.Queries.GetNotificationList
{
    public class GetNotificationListQueryHandler : IRequestHandler<GetNotificationListQuery, NotificationListVm>
    {
        private readonly IConfiguration _configuration;
        private readonly ICurrentUserService _userService;

        public GetNotificationListQueryHandler(IConfiguration configuration, ICurrentUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        public async Task<NotificationListVm> Handle(GetNotificationListQuery request, CancellationToken cancellationToken)
        {
            var id = _userService.GetUserId();

            var model = new NotificationListVm();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DieteticSNSDatabase")))
            {
                var roles = await connection.QueryAsync<NotificationDto>($@"
                    SELECT Notifications.Id, UserId, NotificationType, CreatedAt, FirstName, LastName, AvatarPath
                    FROM Notifications LEFT OUTER JOIN AspNetUsers ON Notifications.UserId = AspNetUsers.Id
                    WHERE RecipientId = { id }
                    ORDER BY CreatedAt DESC;
                ");

                foreach (var role in roles)
                {
                    switch (role.NotificationType)
                    {
                        case NotificationType.PostComment:
                            role.NotificationText = "commented on your post.";
                            break;
                        case NotificationType.PostLike:
                            role.NotificationText = "liked your post.";
                            break;
                        case NotificationType.CommentLike:
                            role.NotificationText = "liked your comment.";
                            break;
                        case NotificationType.UserFollowing:
                            role.NotificationText = "is now following you.";
                            break;
                        case NotificationType.UserUnfollowing:
                            role.NotificationText = "stopped following you.";
                            break;
                    }
                }

                model.Notifications = roles.ToList();
            }

            return model;
        }
    }
}
