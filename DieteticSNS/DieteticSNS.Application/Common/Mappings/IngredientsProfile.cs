using AutoMapper;
using DieteticSNS.Application.Models.Ingredients.Commands.UpdateIngredient;
using DieteticSNS.Application.Models.Ingredients.Queries.GetIngredientDetails;

namespace DieteticSNS.Application.Common.Mappings
{
    public class IngredientsProfile : Profile
    {
        public IngredientsProfile()
        {
            CreateMap<IngredientDetailsVm, UpdateIngredientCommand>();
        }
    }
}
