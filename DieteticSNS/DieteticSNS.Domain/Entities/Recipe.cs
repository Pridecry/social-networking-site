using System;
using System.Collections.Generic;
using DieteticSNS.Domain.Entities.Base;

namespace DieteticSNS.Domain.Entities
{
    public class Recipe : BaseTimeStampEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; private set; } = new HashSet<RecipeIngredient>();
        public virtual ICollection<RecipeComment> RecipeComments { get; private set; } = new HashSet<RecipeComment>();
        public virtual ICollection<RecipeReport> RecipeReports { get; private set; } = new HashSet<RecipeReport>();
        public virtual ICollection<RecipeStars> RecipeStars { get; private set; } = new HashSet<RecipeStars>();
    }
}
