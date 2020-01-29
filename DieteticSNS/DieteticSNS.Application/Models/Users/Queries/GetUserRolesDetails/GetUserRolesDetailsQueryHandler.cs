using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace DieteticSNS.Application.Models.Users.Queries.GetUserRolesDetails
{
    public class GetUserRolesDetailsQueryHandler : IRequestHandler<GetUserRolesDetailsQuery, UserRolesDetailsVm>
    {
        private readonly IConfiguration _configuration;

        public GetUserRolesDetailsQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<UserRolesDetailsVm> Handle(GetUserRolesDetailsQuery request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DieteticSNSDatabase")))
            {
                var model = new UserRolesDetailsVm();

                var userRoles = await connection.QueryAsync<string>($@"
                    SELECT Name 
                    FROM AspNetUserRoles userRoles LEFT OUTER JOIN AspNetRoles roles ON userRoles.RoleId = roles.Id 
                    WHERE userId = { request.UserId };
                ");
                
                var roles = await connection.QueryAsync<string>($@"
                    SELECT Name 
                    FROM AspNetRoles;
                ");

                foreach (var role in roles)
                {
                    var roleDto = new RoleDto { RoleName = role };

                    if (userRoles.Contains(role))
                    {
                        roleDto.IsSelected = true;
                    }

                    model.UserRoles.Add(roleDto);
                }

                return model;
            }
        }
    }
}
