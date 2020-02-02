using MediatR;

namespace DieteticSNS.Application.Models.Reports.Commands.DeleteCommentReports
{
    public class DeleteCommentReportsCommand : IRequest
    {
        public int Id { get; set; }
    }
}
