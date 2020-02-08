using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using DieteticSNS.Application.Common.Interfaces;
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
                    SELECT Notifications.Id, UserId, CreatedAt, FirstName, LastName, AvatarPath
                    FROM Notifications LEFT OUTER JOIN AspNetUsers ON Notifications.UserId = AspNetUsers.Id
                    WHERE RecipientId = { id }
                    ORDER BY CreatedAt DESC;
                ");

                model.Notifications = roles.ToList();
            }

            return model;
        }
    }
}
