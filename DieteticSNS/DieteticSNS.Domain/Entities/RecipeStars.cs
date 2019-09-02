using System;

namespace DieteticSNS.Domain.Entities
{
    public class RecipeStars
    {
        public Guid RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }

        public Guid StarsId { get; set; }
        public virtual Stars Stars { get; set; }
    }
}
