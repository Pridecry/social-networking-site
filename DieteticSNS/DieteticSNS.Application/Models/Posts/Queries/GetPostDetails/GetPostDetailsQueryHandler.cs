using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using DieteticSNS.Application.Common.Exceptions;
using DieteticSNS.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace DieteticSNS.Application.Models.Posts.Queries.GetPostDetails
{
    public class GetPostDetailsQueryHandler : IRequestHandler<GetPostDetailsQuery, PostDetailsVm>
    {
        private readonly IConfiguration _configuration;

        public GetPostDetailsQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<PostDetailsVm> Handle(GetPostDetailsQuery request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DieteticSNSDatabase")))
            {
                var model = await connection.QueryFirstOrDefaultAsync<PostDetailsVm>($@"
                    SELECT * 
                    FROM Posts
                    WHERE id = { request.Id }
                ");

                if (model == null)
                {
                    throw new NotFoundException(nameof(Post), request.Id);
                }

                return model;
            }
        }
    }
}
