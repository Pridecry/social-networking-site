using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using MediatR;

namespace DieteticSNS.Application.Models.Ingredients.Commands.CreateIngredient
{
    public class CreateIngredientCommandHandler : IRequestHandler<CreateIngredientCommand>
    {
        private readonly IDieteticSNSDbContext _context;
        private readonly IMapper _mapper;

        public CreateIngredientCommandHandler(IDieteticSNSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Ingredient>(request);

            _context.Ingredients.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
