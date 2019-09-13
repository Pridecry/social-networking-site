using System.Collections.Generic;
using DieteticSNS.Domain.Entities;

namespace DieteticSNS.Application.Models.Ingredients.Queries.GetIngredientsList
{
    public class IngredientsModel
    {
        public List<Ingredient> AllIngredients { get; set; }
    }
}
