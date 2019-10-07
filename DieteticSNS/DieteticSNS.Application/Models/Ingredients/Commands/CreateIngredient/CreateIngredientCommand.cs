using MediatR;

namespace DieteticSNS.Application.Models.Ingredients.Commands.CreateIngredient
{
    public class CreateIngredientCommand : IRequest
    {
        public string Name { get; set; }
        public int? Protein { get; set; }
        public int? Carbohydrate { get; set; }
        public int? Fat { get; set; }
    }
}
