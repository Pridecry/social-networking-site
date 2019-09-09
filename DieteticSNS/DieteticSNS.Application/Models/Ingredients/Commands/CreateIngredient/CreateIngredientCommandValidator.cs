using FluentValidation;

namespace DieteticSNS.Application.Models.Ingredients.Commands.CreateIngredient
{
    public class CreateIngredientCommandValidator : AbstractValidator<CreateIngredientCommand>
    {
        public CreateIngredientCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Protein).NotEmpty();
            RuleFor(x => x.Carbohydrate).NotEmpty();
            RuleFor(x => x.Fat).NotEmpty();
        }
    }
}
