using System;
using System.Collections.Generic;
using DieteticSNS.Domain.Entities.Base;

namespace DieteticSNS.Domain.Entities
{
    public class Ingredient : BaseEntity<int>
    {
        public string Name { get; set; }
        public decimal Protein { get; set; }
        public decimal Carbohydrate { get; set; }
        public decimal Fat { get; set; }

        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new HashSet<RecipeIngredient>();
    }
}
