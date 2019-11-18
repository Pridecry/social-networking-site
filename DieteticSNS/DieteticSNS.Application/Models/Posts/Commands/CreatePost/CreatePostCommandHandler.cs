using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using MediatR;

namespace DieteticSNS.Application.Models.Posts.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand>
    {
        private readonly IDieteticSNSDbContext _context;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly ICurrentUserService _userService;

        public CreatePostCommandHandler(IDieteticSNSDbContext context, IMapper mapper, IImageService imageService, ICurrentUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _imageService = imageService;
            _userService = userService;
        }

        public async Task<Unit> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Post>(request);
            entity.UserId = int.Parse(_userService.GetUserId());

            if (request.Photo != null)
            {
                string fileName = _imageService.SaveImage(request.Photo);
                entity.PhotoPath = fileName;
            }

            _context.Posts.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
