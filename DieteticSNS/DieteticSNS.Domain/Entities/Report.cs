using System;
using System.Collections.Generic;
using DieteticSNS.Domain.Entities.Base;

namespace DieteticSNS.Domain.Entities
{
    public class Report : BaseTimeStampEntity
    {
        public Guid AccuserId { get; set; }
        public User Accuser { get; set; }

        public string Content { get; set; }

        public virtual ICollection<RecipeReport> RecipeReports { get; set; } = new HashSet<RecipeReport>();
        public virtual ICollection<PostReport> PostReports { get; set; } = new HashSet<PostReport>();
        public virtual ICollection<CommentReport> CommentReports { get; set; } = new HashSet<CommentReport>();
    }
}
