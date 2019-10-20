using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using DieteticSNS.Application.Common.Exceptions;
using DieteticSNS.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace DieteticSNS.Application.Models.Countries.Queries.GetCountryDetails
{
    public class GetCountryDetailsQueryHandler : IRequestHandler<GetCountryDetailsQuery, CountryDetailsVm>
    {
        private readonly IConfiguration _configuration;

        public GetCountryDetailsQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<CountryDetailsVm> Handle(GetCountryDetailsQuery request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DieteticSNSDatabase")))
            {
                var model = await connection.QueryFirstOrDefaultAsync<CountryDetailsVm>($@"
                    SELECT * 
                    FROM Countries
                    WHERE id = { request.Id }
                ");

                if (model == null)
                {
                    throw new NotFoundException(nameof(Country), request.Id);
                }

                return model;
            }
        }
    }
}
