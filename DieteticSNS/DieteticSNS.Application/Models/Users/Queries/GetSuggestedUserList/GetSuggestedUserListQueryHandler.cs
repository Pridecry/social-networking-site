using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using DieteticSNS.Application.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace DieteticSNS.Application.Models.Users.Queries.GetSuggestedUserList
{
    public class GetSuggestedUserListQueryHandler : IRequestHandler<GetSuggestedUserListQuery, SuggestedUserListVm>
    {
        private readonly IConfiguration _configuration;
        private readonly ICurrentUserService _userService;

        public GetSuggestedUserListQueryHandler(IConfiguration configuration, ICurrentUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        public async Task<SuggestedUserListVm> Handle(GetSuggestedUserListQuery request, CancellationToken cancellationToken)
        {
            var id = _userService.GetUserId();

            var model = new SuggestedUserListVm();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DieteticSNSDatabase")))
            {
                var friendIds = await connection.QueryAsync<int>($@"
                    SELECT Id
                    FROM AspNetUsers LEFT OUTER JOIN Followings ON AspNetUsers.Id = Followings.UserId
                    WHERE FollowerId = { id }
                    AND SYSDATETIME() > IIF(LockoutEnd IS NULL, DATEADD(minute, -1, SYSDATETIME()), LockoutEnd);
                ");

                if (friendIds.Count() != 0)
                {
                    string friendIdSet = $"({ id },";

                    foreach (var friendId in friendIds)
                    {
                        friendIdSet += friendId + ", ";
                    }

                    friendIdSet = friendIdSet.Remove(friendIdSet.Length - 2) + ")";

                    var suggestedUsers = await connection.QueryAsync<SuggestedUserDto>($@"
                        SELECT TOP 4 Id, FirstName, LastName, AvatarPath, COUNT(Id) FollowersCount
                        FROM AspNetUsers LEFT OUTER JOIN Followings ON AspNetUsers.Id = Followings.UserId
                        WHERE Id NOT IN { friendIdSet }
                        AND SYSDATETIME() > IIF(LockoutEnd IS NULL, DATEADD(minute, -1, SYSDATETIME()), LockoutEnd)
                        GROUP BY Id, FirstName, LastName, AvatarPath
                        ORDER BY FollowersCount DESC;
                    ");

                    model.Users = suggestedUsers.ToList();
                }
                else
                {
                    var suggestedUsers = await connection.QueryAsync<SuggestedUserDto>($@"
                        SELECT TOP 4 Id, FirstName, LastName, AvatarPath, COUNT(Id) FollowersCount
                        FROM AspNetUsers LEFT OUTER JOIN Followings ON AspNetUsers.Id = Followings.UserId
                        WHERE Id != { id }
                        AND SYSDATETIME() > IIF(LockoutEnd IS NULL, DATEADD(minute, -1, SYSDATETIME()), LockoutEnd)
                        GROUP BY Id, FirstName, LastName, AvatarPath
                        ORDER BY FollowersCount DESC;
                    ");

                    model.Users = suggestedUsers.ToList();
                }
            }

            return model;
        }
    }
}
