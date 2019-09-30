using System.Threading;
using System.Threading.Tasks;
using DieteticSNS.Application.Exceptions;
using DieteticSNS.Application.Interfaces;
using DieteticSNS.Domain.Entities;
using MediatR;

namespace DieteticSNS.Application.Models.Ingredients.Commands.UpdateIngredient
{
    public class UpdateIngredientCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Protein { get; set; }
        public int? Carbohydrate { get; set; }
        public int? Fat { get; set; }

        public class Handler : IRequestHandler<UpdateIngredientCommand, Unit>
        {
            private readonly IDieteticSNSDbContext _context;

            public Handler(IDieteticSNSDbContext context)
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
}
