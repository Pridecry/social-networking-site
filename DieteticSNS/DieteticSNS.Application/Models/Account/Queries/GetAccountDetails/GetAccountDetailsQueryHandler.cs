using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using DieteticSNS.Application.Common.Exceptions;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace DieteticSNS.Application.Models.Account.Queries.GetUserDetails
{
    public class GetAccountDetailsQueryHandler : IRequestHandler<GetAccountDetailsQuery, AccountDetailsVm>
    {
        private readonly IConfiguration _configuration;
        private readonly ICurrentUserService _userService;

        public GetAccountDetailsQueryHandler(IConfiguration configuration, ICurrentUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        public async Task<AccountDetailsVm> Handle(GetAccountDetailsQuery request, CancellationToken cancellationToken)
        {
            var id = _userService.GetUserId();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DieteticSNSDatabase")))
            {
                var model = await connection.QueryFirstOrDefaultAsync<AccountDetailsVm>($@"
                    SELECT * 
                    FROM AspNetUsers
                    WHERE id = { id }
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
