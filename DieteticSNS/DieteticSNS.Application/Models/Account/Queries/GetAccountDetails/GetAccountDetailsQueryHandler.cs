using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using DieteticSNS.Application.Common.Exceptions;
using DieteticSNS.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace DieteticSNS.Application.Models.Account.Queries.GetUserDetails
{
    public class GetAccountDetailsQueryHandler : IRequestHandler<GetAccountDetailsQuery, AccountDetailsVm>
    {
        private readonly IConfiguration _configuration;

        public GetAccountDetailsQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<AccountDetailsVm> Handle(GetAccountDetailsQuery request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DieteticSNSDatabase")))
            {
                var model = await connection.QueryFirstOrDefaultAsync<AccountDetailsVm>($@"
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
