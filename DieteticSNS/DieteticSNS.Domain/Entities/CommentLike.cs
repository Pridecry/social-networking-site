using System;

namespace DieteticSNS.Domain.Entities
{
    public class CommentLike
    {
        public Guid CommentId { get; set; }
        public virtual Comment Comment { get; set; }

        public Guid LikeId { get; set; }
        public virtual Like Like { get; set; }
    }
}
