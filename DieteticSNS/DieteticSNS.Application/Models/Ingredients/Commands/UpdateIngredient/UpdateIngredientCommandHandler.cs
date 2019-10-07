using System.Threading;
using System.Threading.Tasks;
using DieteticSNS.Application.Common.Exceptions;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using MediatR;

namespace DieteticSNS.Application.Models.Ingredients.Commands.UpdateIngredient
{
    public class UpdateIngredientCommandHandler : IRequestHandler<UpdateIngredientCommand>
    {
        private readonly IDieteticSNSDbContext _context;

        public UpdateIngredientCommandHandler(IDieteticSNSDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateIngredientCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Ingredients.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Ingredient), request.Id);
            }

            entity.Name = request.Name;
            entity.Protein = request.Protein;
            entity.Carbohydrate = request.Carbohydrate;
            entity.Fat = request.Fat;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
