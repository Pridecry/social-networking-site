using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace DieteticSNS.Application.Models.Followings.Queries.GetFollowingsList
{
    public class GetFollowingsListQueryHandler : IRequestHandler<GetFollowingsListQuery, FollowingsListVm>
    {
        private readonly IConfiguration _configuration;

        public GetFollowingsListQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<FollowingsListVm> Handle(GetFollowingsListQuery request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DieteticSNSDatabase")))
            {
                var model = await connection.QueryFirstOrDefaultAsync<FollowingsListVm>($@"
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

                var followings = await connection.QueryAsync<FollowingDto>($@"
                    SELECT Id, FirstName, LastName, AvatarPath
                    FROM AspNetUsers LEFT OUTER JOIN Followings on AspNetUsers.Id = Followings.UserId
                    WHERE FollowerId = { request.Id }
                    AND SYSDATETIME() > IIF(LockoutEnd IS NULL, DATEADD(minute, -1, SYSDATETIME()), LockoutEnd);
                ");
                model.Followings = followings.ToList();

                return model;
            }
        }
    }
}
