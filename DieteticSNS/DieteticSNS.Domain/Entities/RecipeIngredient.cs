using System;
using DieteticSNS.Domain.Enumerations;

namespace DieteticSNS.Domain.Entities
{
    public class RecipeIngredient
    {
        public Guid RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }

        public Guid IngredientId { get; set; }
        public virtual Ingredient Ingredient { get; set; }

        public decimal Quantity { get; set; }
        public UnitOfMass Unit { get; set; }
    }
}
