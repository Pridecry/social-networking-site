using MediatR;

namespace DieteticSNS.Application.Models.Ingredients.Commands.UpdateIngredient
{
    public class UpdateIngredientCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Protein { get; set; }
        public int? Carbohydrate { get; set; }
        public int? Fat { get; set; }  
    }
}
