using System;
using DieteticSNS.Domain.Enumerations;

namespace DieteticSNS.Domain.Entities
{
    public class RecipeIngredient
    {
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }

        public int IngredientId { get; set; }
        public virtual Ingredient Ingredient { get; set; }

        public int Quantity { get; set; }
        public Unit Unit { get; set; }
    }
}
