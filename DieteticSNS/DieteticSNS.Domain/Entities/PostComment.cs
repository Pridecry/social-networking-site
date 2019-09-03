using System;

namespace DieteticSNS.Domain.Entities
{
    public class PostComment : Comment
    {
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
