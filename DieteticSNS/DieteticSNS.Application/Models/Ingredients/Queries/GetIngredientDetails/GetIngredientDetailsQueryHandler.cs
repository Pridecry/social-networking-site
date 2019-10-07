using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using DieteticSNS.Application.Common.Exceptions;
using DieteticSNS.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace DieteticSNS.Application.Models.Ingredients.Queries.GetIngredientDetails
{
    public class GetIngredientDetailsQueryHandler : IRequestHandler<GetIngredientDetailsQuery, IngredientDetailsVm>
    {
        private readonly IConfiguration _configuration;

        public GetIngredientDetailsQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IngredientDetailsVm> Handle(GetIngredientDetailsQuery request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DieteticSNSDatabase")))
            {
                var model = await connection.QueryFirstOrDefaultAsync<IngredientDetailsVm>($@"
                        SELECT * 
                        FROM Ingredients
                        WHERE id = { request.Id }
                    ");

                if (model == null)
                {
                    throw new NotFoundException(nameof(Ingredient), request.Id);
                }

                return model;
            }
        }
    }
}
