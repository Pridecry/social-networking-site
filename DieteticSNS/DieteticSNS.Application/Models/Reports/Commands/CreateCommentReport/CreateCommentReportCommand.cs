using MediatR;

namespace DieteticSNS.Application.Models.Reports.Commands.CreateCommentReport
{
    public class CreateCommentReportCommand : IRequest
    {
        public int CommentId { get; set; }
    }
}
