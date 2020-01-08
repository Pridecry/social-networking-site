using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using MediatR;

namespace DieteticSNS.Application.Models.Likes.Commands.CreateCommentLike
{
    public class CreateCommentLikeCommandHandler : IRequestHandler<CreateCommentLikeCommand>
    {
        private readonly IDieteticSNSDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _userService;
        private readonly IWallService _wallService;

        public CreateCommentLikeCommandHandler(IDieteticSNSDbContext context, IMapper mapper, ICurrentUserService userService, IWallService wallService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
            _wallService = wallService;
        }

        public async Task<Unit> Handle(CreateCommentLikeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CommentLike>(request);
            entity.UserId = int.Parse(_userService.GetUserId());

            _context.CommentLikes.Add(entity);

            if (await _context.SaveChangesAsync(cancellationToken) > 0)
            {
                var item = _context.CommentLikes
                    .Where(x => x.CommentId == entity.CommentId && x.UserId == entity.UserId)
                    .FirstOrDefault();

                await _wallService.SendCommentLike(entity.UserId, item.Id, item.CommentId);
            }

            return Unit.Value;
        }
    }
}
