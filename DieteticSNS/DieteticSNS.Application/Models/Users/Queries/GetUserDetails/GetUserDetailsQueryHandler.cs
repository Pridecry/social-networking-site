using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using DieteticSNS.Application.Common.Exceptions;
using DieteticSNS.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace DieteticSNS.Application.Models.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsVm>
    {
        private readonly IConfiguration _configuration;

        public GetUserDetailsQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<UserDetailsVm> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DieteticSNSDatabase")))
            {
                var model = await connection.QueryFirstOrDefaultAsync<UserDetailsVm>($@"
                    SELECT * 
                    FROM AspNetUsers
                    WHERE id = { request.Id }
                ");

                if (model == null)
                {
                    throw new NotFoundException(nameof(User), request.Id);
                }

                return model;
            }
        }
    }
}
