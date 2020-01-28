using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DieteticSNS.Application.Common.Exceptions;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using MediatR;

namespace DieteticSNS.Application.Models.Account.Commands.UpdateAccount
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand>
    {
        private readonly IDieteticSNSDbContext _context;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public UpdateAccountCommandHandler(IDieteticSNSDbContext context, IMapper mapper, IImageService imageService)
        {
            _context = context;
            _mapper = mapper;
            _imageService = imageService;
        }

        public async Task<Unit> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            if (request.Avatar != null)
            {
                string fileName = _imageService.SaveImage(request.Avatar);
                //await request.Avatar.CopyToAsync(new FileStream(filePath, FileMode.Create));

                if (entity.AvatarPath != null)
                {
                    _imageService.DeleteImage(entity.AvatarPath);
                }

                entity.AvatarPath = fileName;
            }

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
