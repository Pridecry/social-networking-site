using System;

namespace DieteticSNS.Domain.Entities
{
    public class PostComment : Comment
    {
        public Guid PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
