using System.Threading;
using System.Threading.Tasks;
using DieteticSNS.Application.Common.Exceptions;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using MediatR;

namespace DieteticSNS.Application.Models.Users.Commands.DeleteAvatar
{
    public class DeleteAvatarCommandHandler : IRequestHandler<DeleteAvatarCommand>
    {
        private readonly IDieteticSNSDbContext _context;
        private readonly IImageService _imageService;

        public DeleteAvatarCommandHandler(IDieteticSNSDbContext context, IImageService imageService)
        {
            _context = context;
            _imageService = imageService;
        }

        public async Task<Unit> Handle(DeleteAvatarCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            if (entity.AvatarPath != null)
            {
                _imageService.DeleteImage(entity.AvatarPath);
                entity.AvatarPath = null;
            }            

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
