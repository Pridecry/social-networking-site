using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DieteticSNS.Application.Common.Exceptions;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DieteticSNS.Application.Models.Account.Commands.DeleteAccount
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand>
    {
        private readonly IDieteticSNSDbContext _context;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly ICurrentUserService _userService;

        public DeleteAccountCommandHandler(IDieteticSNSDbContext context, IMapper mapper, IImageService imageService, ICurrentUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _imageService = imageService;
            _userService = userService;
        }

        public async Task<Unit> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var id = int.Parse(_userService.GetUserId());

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
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), id);
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
