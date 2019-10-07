using System.Threading;
using System.Threading.Tasks;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using MediatR;

namespace DieteticSNS.Application.Models.Ingredients.Commands.CreateIngredient
{
    public class CreateIngredientCommandHandler : IRequestHandler<CreateIngredientCommand>
    {
        private readonly IDieteticSNSDbContext _context;

        public CreateIngredientCommandHandler(IDieteticSNSDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
        {
            var entity = new Ingredient
            {
                Name = request.Name,
                Protein = request.Protein,
                Carbohydrate = request.Carbohydrate,
                Fat = request.Fat
            };

            _context.Ingredients.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
