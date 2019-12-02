using MediatR;

namespace DieteticSNS.Application.Models.Reports.Commands.DeleteReport
{
    public class DeleteReportCommand : IRequest
    {
        public int Id { get; set; }
    }
}
