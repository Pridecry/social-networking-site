using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using DieteticSNS.Application.Models.Posts.Queries.GetPostsList;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace DieteticSNS.Application.Models.Posts.Queries.GetPostList
{
    public class GetPostListQueryHandler : IRequestHandler<GetPostListQuery, PostListVm>
    {
        private readonly IConfiguration _configuration;

        public GetPostListQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<PostListVm> Handle(GetPostListQuery request, CancellationToken cancellationToken)
        {
            var model = new PostListVm();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DieteticSNSDatabase")))
            {
                var Posts = await connection.QueryAsync<PostDto>($@"
                    SELECT posts.Id, UserId, Title, Description, PhotoPath, CreatedAt, FirstName, LastName, AvatarPath
                    FROM dbo.Posts posts LEFT OUTER JOIN dbo.AspNetUsers users ON posts.UserId = users.Id
                    ORDER BY CreatedAt DESC;
                ");

                model.Posts = Posts.ToList();
            }

            return model;
        }
    }
}
