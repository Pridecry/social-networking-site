using System;

namespace DieteticSNS.Domain.Entities
{
    public class RecipeStars : Stars
    {
        public Guid RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
