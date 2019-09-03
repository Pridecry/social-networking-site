using System;
using System.Collections.Generic;
using DieteticSNS.Domain.Entities.Base;

namespace DieteticSNS.Domain.Entities
{
    public class Post : BaseTimeStampEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public string Description { get; set; }
        public string ImageURL { get; set; }

        public virtual ICollection<PostComment> PostComments { get; set; } = new HashSet<PostComment>();
        public virtual ICollection<PostReport> PostReports { get; set; } = new HashSet<PostReport>();
        public virtual ICollection<PostLike> PostLikes { get; set; } = new HashSet<PostLike>();
    }
}
