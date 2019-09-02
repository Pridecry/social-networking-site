using System;

namespace DieteticSNS.Domain.Entities
{
    public class CommentReport
    {
        public Guid CommentId { get; set; }
        public virtual Comment Comment { get; set; }

        public Guid ReportId { get; set; }
        public virtual Report Report { get; set; }
    }
}
