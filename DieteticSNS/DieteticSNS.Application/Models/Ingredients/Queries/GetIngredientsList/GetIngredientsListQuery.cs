using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using DieteticSNS.Application.Interfaces;
using DieteticSNS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DieteticSNS.Application.Models.Ingredients.Queries.GetIngredientsList
{
    public class GetIngredientsListQuery : IRequest<IngredientsModel>
    {
        public class Handler : IRequestHandler<GetIngredientsListQuery, IngredientsModel>
        {
            private readonly IDieteticSNSDbContext _context;
            private readonly IConfiguration _configuration;

            public Handler(IDieteticSNSDbContext context, IConfiguration configuration)
            {
                _context = context;
                _configuration = configuration;
            }

            public async Task<IngredientsModel> Handle(GetIngredientsListQuery request, CancellationToken cancellationToken)
            {
                var model = new IngredientsModel();

                using (var connection = new SqlConnection(_configuration.GetConnectionString("DieteticSNSDatabase")))
                {
                    model.AllIngredients = connection.Query<Ingredient>("Select * From Ingredients").ToList();
                }

                return model;


                    return new IngredientsModel
                {
                    AllIngredients = await _context.Ingredients.ToListAsync()
                };
            }
        }
    }
}
