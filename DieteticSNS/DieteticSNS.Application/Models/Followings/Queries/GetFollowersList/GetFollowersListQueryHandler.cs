using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace DieteticSNS.Application.Models.Followings.Queries.GetFollowersList
{
    public class GetFollowersListQueryHandler : IRequestHandler<GetFollowersListQuery, FollowersListVm>
    {
        private readonly IConfiguration _configuration;

        public GetFollowersListQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<FollowersListVm> Handle(GetFollowersListQuery request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DieteticSNSDatabase")))
            {
                var model = await connection.QueryFirstOrDefaultAsync<FollowersListVm>($@"
                    SELECT Id, UserName, FirstName, LastName, AvatarPath,
                        (SELECT COUNT(UserId)
	                    FROM Followings
	                    WHERE UserId = users.Id
	                    GROUP BY UserId) FollowersCount,
	                    (SELECT COUNT(FollowerId)
	                    FROM Followings
	                    WHERE FollowerId = users.Id
	                    GROUP BY FollowerId) FollowingsCount,
                        (SELECT COUNT(UserId)
	                    FROM Posts
	                    WHERE UserId = users.Id
	                    GROUP BY UserId) PostCount
                    FROM AspNetUsers users
                    WHERE Id = { request.Id }
                ");

                var followers = await connection.QueryAsync<FollowerDto>($@"
                    SELECT Id, FirstName, LastName, AvatarPath
                    FROM AspNetUsers LEFT OUTER JOIN Followings on AspNetUsers.Id = Followings.FollowerId
                    WHERE UserId = { request.Id }
                    AND SYSDATETIME() > IIF(LockoutEnd IS NULL, DATEADD(minute, -1, SYSDATETIME()), LockoutEnd);
                ");
                model.Followers = followers.ToList();

                return model;
            }
        }
    }
}
