using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using DieteticSNS.Application.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace DieteticSNS.Application.Models.Roles.Queries.GetRoleDetails
{
    public class GetRoleDetailsQueryHandler : IRequestHandler<GetRoleDetailsQuery, RoleDetailsVm>
    {
        private readonly IConfiguration _configuration;

        public GetRoleDetailsQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<RoleDetailsVm> Handle(GetRoleDetailsQuery request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DieteticSNSDatabase")))
            {
                var model = await connection.QueryFirstOrDefaultAsync<RoleDetailsVm>($@"
                    SELECT * 
                    FROM AspNetRoles
                    WHERE id = { request.Id }
                ");

                if (model == null)
                {
                    throw new NotFoundException(nameof(IdentityRole), request.Id);
                }

                return model;
            }
        }
    }
}
