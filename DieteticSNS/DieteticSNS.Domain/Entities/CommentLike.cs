using System;

namespace DieteticSNS.Domain.Entities
{
    public class CommentLike : Like
    {
        public Guid CommentId { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
