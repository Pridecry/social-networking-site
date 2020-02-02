using MediatR;

namespace DieteticSNS.Application.Models.Reports.Commands.DeletePostReports
{
    public class DeletePostReportsCommand : IRequest
    {
        public int Id { get; set; }
    }
}
