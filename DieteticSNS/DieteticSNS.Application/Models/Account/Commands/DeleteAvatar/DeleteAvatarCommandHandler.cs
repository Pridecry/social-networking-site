using System.Threading;
using System.Threading.Tasks;
using DieteticSNS.Application.Common.Exceptions;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using MediatR;

namespace DieteticSNS.Application.Models.Account.Commands.DeleteAvatar
{
    public class DeleteAvatarCommandHandler : IRequestHandler<DeleteAvatarCommand>
    {
        private readonly IDieteticSNSDbContext _context;
        private readonly IImageService _imageService;
        private readonly ICurrentUserService _userService;

        public DeleteAvatarCommandHandler(IDieteticSNSDbContext context, IImageService imageService, ICurrentUserService userService)
        {
            _context = context;
            _imageService = imageService;
            _userService = userService;
        }

        public async Task<Unit> Handle(DeleteAvatarCommand request, CancellationToken cancellationToken)
        {
            var id = int.Parse(_userService.GetUserId());

            var entity = await _context.Users.FindAsync(id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), id);
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
