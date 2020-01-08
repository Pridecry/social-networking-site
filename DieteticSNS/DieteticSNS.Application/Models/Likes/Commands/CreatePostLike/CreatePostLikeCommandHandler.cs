using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using MediatR;

namespace DieteticSNS.Application.Models.Likes.Commands.CreatePostLike
{
    public class CreatePostLikeCommandHandler : IRequestHandler<CreatePostLikeCommand>
    {
        private readonly IDieteticSNSDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _userService;
        private readonly IWallService _wallService;


        public CreatePostLikeCommandHandler(IDieteticSNSDbContext context, IMapper mapper, ICurrentUserService userService, IWallService wallService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
            _wallService = wallService;
        }

        public async Task<Unit> Handle(CreatePostLikeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PostLike>(request);
            entity.UserId = int.Parse(_userService.GetUserId());

            _context.PostLikes.Add(entity);

            if (await _context.SaveChangesAsync(cancellationToken) > 0)
            {
                var item = _context.PostLikes
                    .Where(x => x.PostId == entity.PostId && x.UserId == entity.UserId)
                    .FirstOrDefault();

                await _wallService.SendPostLike(entity.UserId, item.Id, item.PostId);
            }

            return Unit.Value;
        }
    }
}
