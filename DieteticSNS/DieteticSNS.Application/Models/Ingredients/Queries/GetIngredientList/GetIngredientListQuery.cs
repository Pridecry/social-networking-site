using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace DieteticSNS.Application.Models.Ingredients.Queries.GetIngredientsList
{
    public class GetIngredientListQuery : IRequest<IngredientListModel>
    {
        public class Handler : IRequestHandler<GetIngredientListQuery, IngredientListModel>
        {
            private readonly IConfiguration _configuration;

            public Handler(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public async Task<IngredientListModel> Handle(GetIngredientListQuery request, CancellationToken cancellationToken)
            {
                var model = new IngredientListModel();

                using (var connection = new SqlConnection(_configuration.GetConnectionString("DieteticSNSDatabase")))
                {
                    var ingredients = await connection.QueryAsync<IngredientModel>($@"
                        SELECT * 
                        FROM Ingredients
                    ");

                    model.Ingredients = ingredients.ToList();
                }

                return model;
            }
        }
    }
}
