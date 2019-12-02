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

        public CreateCommentLikeCommandHandler(IDieteticSNSDbContext context, IMapper mapper, ICurrentUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<Unit> Handle(CreateCommentLikeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CommentLike>(request);
            entity.UserId = int.Parse(_userService.GetUserId());

            _context.CommentLikes.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
