using MediatR;

namespace DieteticSNS.Application.Models.Ingredients.Commands.DeleteIngredient
{
    public class DeleteIngredientCommand : IRequest
    {
        public int Id { get; set; }
    }
}
