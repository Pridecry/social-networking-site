using System;
using System.Collections.Generic;
using DieteticSNS.Domain.Entities.Base;

namespace DieteticSNS.Domain.Entities
{
    public class Like : BaseTimeStampEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public virtual ICollection<PostLike> PostLikes { get; set; } = new HashSet<PostLike>();
        public virtual ICollection<CommentLike> CommentLikes { get; set; } = new HashSet<CommentLike>();
    }
}
