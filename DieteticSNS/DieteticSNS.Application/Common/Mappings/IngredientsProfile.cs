using AutoMapper;
using DieteticSNS.Application.Models.Ingredients.Commands.CreateIngredient;
using DieteticSNS.Application.Models.Ingredients.Commands.UpdateIngredient;
using DieteticSNS.Application.Models.Ingredients.Queries.GetIngredientDetails;
using DieteticSNS.Domain.Entities;

namespace DieteticSNS.Application.Common.Mappings
{
    public class IngredientsProfile : Profile
    {
        public IngredientsProfile()
        {
            CreateMap<UpdateIngredientCommand, Ingredient>();
            CreateMap<CreateIngredientCommand, Ingredient>();

            CreateMap<IngredientDetailsVm, UpdateIngredientCommand>();
        }
    }
}
