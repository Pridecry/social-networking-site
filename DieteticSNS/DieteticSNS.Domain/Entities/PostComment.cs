using System;

namespace DieteticSNS.Domain.Entities
{
    public class PostComment
    {
        public Guid PostId { get; set; }
        public virtual Post Post { get; set; }

        public Guid CommentId { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
