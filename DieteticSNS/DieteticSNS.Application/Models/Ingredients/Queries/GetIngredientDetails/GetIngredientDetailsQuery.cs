using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using DieteticSNS.Application.Exceptions;
using DieteticSNS.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace DieteticSNS.Application.Models.Ingredients.Queries.GetIngredientDetails
{
    public class GetIngredientDetailsQuery : IRequest<IngredientDetailsModel>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetIngredientDetailsQuery, IngredientDetailsModel>
        {
            private readonly IConfiguration _configuration;

            public Handler(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public async Task<IngredientDetailsModel> Handle(GetIngredientDetailsQuery request, CancellationToken cancellationToken)
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DieteticSNSDatabase")))
                {
                    var model = await connection.QueryFirstOrDefaultAsync<IngredientDetailsModel>($@"
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
}
