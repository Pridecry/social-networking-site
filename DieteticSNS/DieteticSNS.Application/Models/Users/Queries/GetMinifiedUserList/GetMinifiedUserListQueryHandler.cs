using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace DieteticSNS.Application.Models.Users.Queries.GetMinifiedUserList
{
    public class GetMinifiedUserListQueryHandler : IRequestHandler<GetMinifiedUserListQuery, MinifiedUserListVm>
    {
        private readonly IConfiguration _configuration;

        public GetMinifiedUserListQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<MinifiedUserListVm> Handle(GetMinifiedUserListQuery request, CancellationToken cancellationToken)
        {
            var model = new MinifiedUserListVm();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DieteticSNSDatabase")))
            {
                var MinifiedUsers = await connection.QueryAsync<MinifiedUserDto>($@"
                    SELECT Id, FirstName, LastName, AvatarPath
                    FROM AspNetUsers
                    WHERE SYSDATETIME() > IIF(LockoutEnd IS NULL, DATEADD(minute, -1, SYSDATETIME()), LockoutEnd);
                ");

                model.Users = MinifiedUsers.ToList();
            }

            return model;
        }
    }
}
