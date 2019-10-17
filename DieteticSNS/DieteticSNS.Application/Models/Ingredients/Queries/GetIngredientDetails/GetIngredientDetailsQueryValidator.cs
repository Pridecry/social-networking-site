using FluentValidation;

namespace DieteticSNS.Application.Models.Ingredients.Queries.GetIngredientDetails
{
    public class GetIngredientDetailsQueryValidator : AbstractValidator<GetIngredientDetailsQuery>
    {
        public GetIngredientDetailsQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
