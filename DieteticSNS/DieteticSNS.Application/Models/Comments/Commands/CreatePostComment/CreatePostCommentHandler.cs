using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using MediatR;

namespace DieteticSNS.Application.Models.Comments.Commands.CreatePostComment
{
    public class CreatePostCommentCommandHandler : IRequestHandler<CreatePostCommentCommand>
    {
        private readonly IDieteticSNSDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _userService;
        private readonly IWallService _wallService;


        public CreatePostCommentCommandHandler(IDieteticSNSDbContext context, IMapper mapper, ICurrentUserService userService, IWallService wallService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
            _wallService = wallService;
        }

        public async Task<Unit> Handle(CreatePostCommentCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PostComment>(request);
            entity.UserId = int.Parse(_userService.GetUserId());

            _context.PostComments.Add(entity);

            if (await _context.SaveChangesAsync(cancellationToken) > 0)
            {
                var item = _context.PostComments
                    .Where(x => x.PostId == entity.PostId && x.UserId == entity.UserId && x.CreatedAt == entity.CreatedAt)
                    .FirstOrDefault();

                await _wallService.SendPostComment(entity.UserId, item.Id, item.PostId, item.Content);
            }

            return Unit.Value;
        }
    }
}
