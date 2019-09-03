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

        public decimal Quantity { get; set; }
        public UnitOfMass Unit { get; set; }
    }
}
