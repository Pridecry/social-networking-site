using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace DieteticSNS.Application.Models.Countries.Queries.GetCountryList
{
    public class GetCountryListQueryHandler : IRequestHandler<GetCountryListQuery, CountryListVm>
    {
        private readonly IConfiguration _configuration;

        public GetCountryListQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<CountryListVm> Handle(GetCountryListQuery request, CancellationToken cancellationToken)
        {
            var model = new CountryListVm();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DieteticSNSDatabase")))
            {
                var Countries = await connection.QueryAsync<CountryDto>($@"
                    SELECT * 
                    FROM Countries
                    ORDER BY Name
                ");

                model.Countries = Countries.ToList();
            }

            return model;
        }
    }
}
