using FluentValidation;

namespace DieteticSNS.Application.Models.Ingredients.Commands.UpdateIngredient
{
    public class UpdateIngredientCommandValidator : AbstractValidator<UpdateIngredientCommand>
    {
        public UpdateIngredientCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Protein).NotEmpty();
            RuleFor(x => x.Carbohydrate).NotEmpty();
            RuleFor(x => x.Fat).NotEmpty();
        }
    }
}
