using MediatR;

namespace DieteticSNS.Application.Models.Reports.Commands.CreatePostReport
{
    public class CreatePostReportCommand : IRequest
    {
        public int PostId { get; set; }
    }
}
