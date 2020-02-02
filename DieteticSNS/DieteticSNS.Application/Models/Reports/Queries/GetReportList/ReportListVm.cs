using System.Collections.Generic;

namespace DieteticSNS.Application.Models.Reports.Queries.GetReportList
{
    public class ReportListVm
    {
        public IList<CommentReportDto> CommentReports { get; set; }
        public IList<PostReportDto> PostReports { get; set; }
    }
}
