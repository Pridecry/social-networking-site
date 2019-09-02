using System;

namespace DieteticSNS.Domain.Entities
{
    public class PostLike
    {
        public Guid PostId { get; set; }
        public virtual Post Post { get; set; }

        public Guid LikeId { get; set; }
        public virtual Like Like { get; set; }
    }
}
