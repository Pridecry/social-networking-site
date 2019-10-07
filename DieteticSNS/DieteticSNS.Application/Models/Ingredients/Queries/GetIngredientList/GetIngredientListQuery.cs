using MediatR;

namespace DieteticSNS.Application.Models.Ingredients.Queries.GetIngredientsList
{
    public class GetIngredientListQuery : IRequest<IngredientListVm>
    {
    }
}
