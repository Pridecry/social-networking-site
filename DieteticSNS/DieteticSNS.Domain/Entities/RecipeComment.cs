using System;

namespace DieteticSNS.Domain.Entities
{
    public class RecipeComment : Comment
    {
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
