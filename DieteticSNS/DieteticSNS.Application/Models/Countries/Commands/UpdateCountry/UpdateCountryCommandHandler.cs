using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DieteticSNS.Application.Common.Exceptions;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using MediatR;

namespace DieteticSNS.Application.Models.Countries.Commands.UpdateCountry
{
    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand>
    {
        private readonly IDieteticSNSDbContext _context;
        private readonly IMapper _mapper;

        public UpdateCountryCommandHandler(IDieteticSNSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Countries.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Country), request.Id);
            }

            _mapper.Map(request, entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
