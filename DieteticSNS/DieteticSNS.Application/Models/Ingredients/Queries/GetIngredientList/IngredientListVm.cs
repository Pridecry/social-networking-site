using System.Collections.Generic;

namespace DieteticSNS.Application.Models.Ingredients.Queries.GetIngredientsList
{
    public class IngredientListVm
    {
        public IList<IngredientDto> Ingredients { get; set; }
    }
}
