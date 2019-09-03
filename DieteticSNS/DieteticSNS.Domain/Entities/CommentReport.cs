using System;

namespace DieteticSNS.Domain.Entities
{
    public class CommentReport : Report
    {
        public Guid CommentId { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
