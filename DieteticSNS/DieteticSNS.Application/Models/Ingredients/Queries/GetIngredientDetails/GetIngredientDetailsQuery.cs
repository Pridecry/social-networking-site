using MediatR;

namespace DieteticSNS.Application.Models.Ingredients.Queries.GetIngredientDetails
{
    public class GetIngredientDetailsQuery : IRequest<IngredientDetailsVm>
    {
        public int Id { get; set; } 
    }
}
