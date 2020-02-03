using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace DieteticSNS.Application.Models.Posts.Queries.GetMinifiedPostList
{
    public class GetMinifiedPostListQueryHandler : IRequestHandler<GetMinifiedPostListQuery, MinifiedPostListVm>
    {
        private readonly IConfiguration _configuration;

        public GetMinifiedPostListQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<MinifiedPostListVm> Handle(GetMinifiedPostListQuery request, CancellationToken cancellationToken)
        {
            var model = new MinifiedPostListVm();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DieteticSNSDatabase")))
            {
                var posts = await connection.QueryAsync<MinifiedPostDto>($@"
                    SELECT Posts.Id, UserId, Title, Description, PhotoPath, CreatedAt, FirstName, LastName, AvatarPath, 
	                    (SELECT COUNT(PostId)
	                    FROM Likes
	                    WHERE PostId = posts.Id
	                    GROUP BY PostId) LikeCount
                    FROM Posts LEFT OUTER JOIN AspNetUsers ON Posts.UserId = AspNetUsers.Id
                    WHERE SYSDATETIME() > IIF(LockoutEnd IS NULL, DATEADD(minute, -1, SYSDATETIME()), LockoutEnd)
                    ORDER BY LikeCount DESC;
                ");

                model.Posts = posts.ToList();
            }

            return model;
        }
    }
}
