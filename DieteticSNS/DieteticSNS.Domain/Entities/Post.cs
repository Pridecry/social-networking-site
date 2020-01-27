using System;
using System.Collections.Generic;
using DieteticSNS.Domain.Entities.Base;

namespace DieteticSNS.Domain.Entities
{
    public class Post : BaseTimeStampEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }

        public virtual ICollection<PostComment> PostComments { get; private set; } = new HashSet<PostComment>();
        public virtual ICollection<PostReport> PostReports { get; private set; } = new HashSet<PostReport>();
        public virtual ICollection<PostLike> PostLikes { get; private set; } = new HashSet<PostLike>();
    }
}
