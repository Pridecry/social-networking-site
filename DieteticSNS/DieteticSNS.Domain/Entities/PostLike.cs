using System;

namespace DieteticSNS.Domain.Entities
{
    public class PostLike : Like
    {
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
