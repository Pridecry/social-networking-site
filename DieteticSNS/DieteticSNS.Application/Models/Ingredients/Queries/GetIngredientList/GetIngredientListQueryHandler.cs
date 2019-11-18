using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using DieteticSNS.Application.Models.Ingredients.Queries.GetIngredientsList;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace DieteticSNS.Application.Models.Ingredients.Queries.GetIngredientList
{
    public class GetIngredientListQueryHandler : IRequestHandler<GetIngredientListQuery, IngredientListVm>
    {
        private readonly IConfiguration _configuration;

        public GetIngredientListQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IngredientListVm> Handle(GetIngredientListQuery request, CancellationToken cancellationToken)
        {
            var model = new IngredientListVm();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DieteticSNSDatabase")))
            {
                var ingredients = await connection.QueryAsync<IngredientDto>($@"
                    SELECT * 
                    FROM Ingredients
                ");

                model.Ingredients = ingredients.ToList();
            }

            return model;
        }
    }
}
