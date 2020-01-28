using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace DieteticSNS.Application.Models.Roles.Queries.GetRoleList
{
    public class GetRoleListQueryHandler : IRequestHandler<GetRoleListQuery, RoleListVm>
    {
        private readonly IConfiguration _configuration;

        public GetRoleListQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<RoleListVm> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
        {
            var model = new RoleListVm();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DieteticSNSDatabase")))
            {
                var Roles = await connection.QueryAsync<RoleDto>($@"
                    SELECT * 
                    FROM AspNetRoles
                ");

                model.Roles = Roles.ToList();
            }

            return model;
        }
    }
}
