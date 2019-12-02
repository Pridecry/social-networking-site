using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using MediatR;

namespace DieteticSNS.Application.Models.Reports.Commands.CreateCommentReport
{
    public class CreateCommentReportCommandHandler : IRequestHandler<CreateCommentReportCommand>
    {
        private readonly IDieteticSNSDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _userService;

        public CreateCommentReportCommandHandler(IDieteticSNSDbContext context, IMapper mapper, ICurrentUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<Unit> Handle(CreateCommentReportCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CommentReport>(request);
            entity.AccuserId = int.Parse(_userService.GetUserId());

            _context.CommentReports.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
