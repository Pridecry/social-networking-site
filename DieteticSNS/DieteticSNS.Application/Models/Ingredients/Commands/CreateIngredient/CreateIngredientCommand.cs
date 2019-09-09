using System.Threading;
using System.Threading.Tasks;
using DieteticSNS.Application.Interfaces;
using DieteticSNS.Domain.Entities;
using FluentValidation;
using MediatR;

namespace DieteticSNS.Application.Models.Ingredients.Commands.CreateIngredient
{
    public class CreateIngredientCommand : IRequest
    {
        public string Name { get; set; }
        public int Protein { get; set; }
        public int Carbohydrate { get; set; }
        public int Fat { get; set; }

        public class Handler : IRequestHandler<CreateIngredientCommand, Unit>
        {
            private readonly IDieteticSNSDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IDieteticSNSDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
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
}
