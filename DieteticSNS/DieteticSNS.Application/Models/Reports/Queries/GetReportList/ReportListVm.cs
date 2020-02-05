using System.Collections.Generic;

namespace DieteticSNS.Application.Models.Reports.Queries.GetReportList
{
    public class ReportListVm
    {
        public IList<CommentReportDto> CommentReports { get; set; } = new List<CommentReportDto>();
        public IList<PostReportDto> PostReports { get; set; } = new List<PostReportDto>();
    }
}
