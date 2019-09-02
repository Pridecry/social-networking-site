using System;
using System.Collections.Generic;
using DieteticSNS.Domain.Entities.Base;

namespace DieteticSNS.Domain.Entities
{
    public class Comment : BaseTimeStampEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public string Content { get; set; }

        public virtual ICollection<RecipeComment> RecipeComments { get; set; } = new HashSet<RecipeComment>();
        public virtual ICollection<PostComment> PostComments { get; set; } = new HashSet<PostComment>();
        public virtual ICollection<CommentReport> CommentReports { get; set; } = new HashSet<CommentReport>();
        public virtual ICollection<CommentLike> CommentLikes { get; set; } = new HashSet<CommentLike>();
    }
}
