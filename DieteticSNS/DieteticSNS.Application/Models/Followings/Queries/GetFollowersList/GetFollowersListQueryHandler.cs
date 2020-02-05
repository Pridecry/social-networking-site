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
            var model = new FollowersListVm { Id = request.Id };

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DieteticSNSDatabase")))
            {
                var followers = await connection.QueryAsync<FollowerDto>($@"
                    SELECT Id, FirstName, LastName, AvatarPath
                    FROM AspNetUsers LEFT OUTER JOIN Followings on AspNetUsers.Id = Followings.FollowerId
                    WHERE UserId = { request.Id }
                    AND SYSDATETIME() > IIF(LockoutEnd IS NULL, DATEADD(minute, -1, SYSDATETIME()), LockoutEnd);
                ");

                model.Followers = followers.ToList();
            }

            return model;
        }
    }
}
