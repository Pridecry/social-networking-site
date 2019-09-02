using System;

namespace DieteticSNS.Domain.Entities
{
    public class RecipeComment
    {
        public Guid RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }

        public Guid CommentId { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
