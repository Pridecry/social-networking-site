using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DieteticSNS.Application.Interfaces;
using MediatR;

namespace DieteticSNS.Application.Models.Ingredients.Commands.DeleteIngredient
{
    public class DeleteIngredientCommand : IRequest
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<DeleteIngredientCommand>
        {
            private readonly IDieteticSNSDbContext _context;

            public Handler(IDieteticSNSDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteIngredientCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Ingredients
                    .FindAsync(request.Id);

                if (entity == null)
                {
                    throw new Exception();
                }

                _context.Ingredients.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
