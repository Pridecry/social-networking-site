using System;
using System.Collections.Generic;
using DieteticSNS.Domain.Entities.Base;

namespace DieteticSNS.Domain.Entities
{
    public class Ingredient : BaseEntity<int>
    {
        public string Name { get; set; }
        public int? Protein { get; set; }
        public int? Carbohydrate { get; set; }
        public int? Fat { get; set; }

        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; private set; } = new HashSet<RecipeIngredient>();
    }
}
