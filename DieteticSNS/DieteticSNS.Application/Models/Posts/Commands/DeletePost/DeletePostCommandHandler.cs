using System.Threading;
using System.Threading.Tasks;
using DieteticSNS.Application.Common.Exceptions;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using MediatR;

namespace DieteticSNS.Application.Models.Posts.Commands.DeletePost
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly IDieteticSNSDbContext _context;
        private readonly IImageService _imageService;

        public DeletePostCommandHandler(IDieteticSNSDbContext context, IImageService imageService)
        {
            _context = context;
            _imageService = imageService;
        }

        public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Posts.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Post), request.Id);
            }

            _imageService.DeleteImage(entity.PhotoPath);
            _context.Posts.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
