using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using MediatR;

namespace DieteticSNS.Application.Models.Countries.Commands.CreateCountry
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand>
    {
        private readonly IDieteticSNSDbContext _context;
        private readonly IMapper _mapper;

        public CreateCountryCommandHandler(IDieteticSNSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Country>(request);

            _context.Countries.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
