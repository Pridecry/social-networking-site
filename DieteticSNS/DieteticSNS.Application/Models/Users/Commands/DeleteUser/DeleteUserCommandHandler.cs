using System.Threading;
using System.Threading.Tasks;
using DieteticSNS.Application.Common.Exceptions;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DieteticSNS.Application.Models.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IDieteticSNSDbContext _context;
        private readonly IImageService _imageService;

        public DeleteUserCommandHandler(IDieteticSNSDbContext context, IImageService imageService)
        {
            _context = context;
            _imageService = imageService;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .Include(x => x.Comments)
                .Include(x => x.Posts)
                    .ThenInclude(x => x.PostComments)
                .Include(x => x.Posts)
                    .ThenInclude(x => x.PostReports)
                .Include(x => x.Posts)
                    .ThenInclude(x => x.PostLikes)
                .Include(x => x.Followings)
                .Include(x => x.NotificationsTo)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            if (entity.AvatarPath != null)
            {
                _imageService.DeleteImage(entity.AvatarPath);
            }

            foreach (var post in entity.Posts)
            {
                _imageService.DeleteImage(post.PhotoPath);

                _context.Comments.RemoveRange(post.PostComments);
                _context.Reports.RemoveRange(post.PostReports);
                _context.Likes.RemoveRange(post.PostLikes);
            }

            _context.Comments.RemoveRange(entity.Comments);
            _context.Followings.RemoveRange(entity.Followings);
            _context.Notifications.RemoveRange(entity.NotificationsTo);


            _context.Users.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
