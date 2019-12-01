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

        public CreatePostLikeCommandHandler(IDieteticSNSDbContext context, IMapper mapper, ICurrentUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<Unit> Handle(CreatePostLikeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PostLike>(request);
            entity.UserId = int.Parse(_userService.GetUserId());

            _context.PostLikes.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
