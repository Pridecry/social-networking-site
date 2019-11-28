using System.Collections.Generic;
using DieteticSNS.Domain.Entities.Base;

namespace DieteticSNS.Domain.Entities
{
    public class Comment : BaseTimeStampEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public string Content { get; set; }

        public virtual ICollection<CommentLike> CommentLikes { get; set; } = new HashSet<CommentLike>();
        public virtual ICollection<CommentReport> CommentReports { get; set; } = new HashSet<CommentReport>();
    }
}
