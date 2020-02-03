using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace DieteticSNS.Application.Models.Users.Queries.GetUserList
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, UserListVm>
    {
        private readonly IConfiguration _configuration;

        public GetUserListQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<UserListVm> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var model = new UserListVm();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DieteticSNSDatabase")))
            {
                var users = await connection.QueryAsync<UserDto>($@"
                    SELECT *, IIF( SYSDATETIME() <= IIF(LockoutEnd IS NULL, DATEADD(minute, -1, SYSDATETIME()), LockoutEnd), 'TRUE', 'FALSE') IsBlocked
                    FROM AspNetUsers
                ");

                model.Users = users.ToList();
            }

            return model;
        }
    }
}
