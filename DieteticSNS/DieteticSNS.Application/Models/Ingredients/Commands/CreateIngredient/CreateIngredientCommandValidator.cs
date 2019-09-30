using FluentValidation;

namespace DieteticSNS.Application.Models.Ingredients.Commands.CreateIngredient
{
    public class CreateIngredientCommandValidator : AbstractValidator<CreateIngredientCommand>
    {
        public CreateIngredientCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Protein).NotEmpty().InclusiveBetween(0, 100);
            RuleFor(x => x.Carbohydrate).NotEmpty().InclusiveBetween(0, 100);
            RuleFor(x => x.Fat).NotEmpty().InclusiveBetween(0, 100);
        }
    }
}
