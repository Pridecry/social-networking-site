using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using DieteticSNS.Application.Common.Exceptions;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace DieteticSNS.Application.Models.Account.Queries.GetUserNotificationSettings
{
    public class GetUserNotificationSettingsQueryHandler : IRequestHandler<GetUserNotificationSettingsQuery, UserNotificationSettingsVm>
    {
        private readonly IConfiguration _configuration;
        private readonly ICurrentUserService _userService;

        public GetUserNotificationSettingsQueryHandler(IConfiguration configuration, ICurrentUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        public async Task<UserNotificationSettingsVm> Handle(GetUserNotificationSettingsQuery request, CancellationToken cancellationToken)
        {
            var id = _userService.GetUserId();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DieteticSNSDatabase")))
            {
                var model = await connection.QueryFirstOrDefaultAsync<UserNotificationSettingsVm>($@"
                    SELECT PostComments, PostLikes, CommentLikes, UserFollowings, UserUnfollowings
                    FROM UserNotificationSettings
                    WHERE UserId = { id }
                ");

                if (model == null)
                {
                    throw new NotFoundException(nameof(User), id);
                }

                return model;
            }
        }
    }
}
