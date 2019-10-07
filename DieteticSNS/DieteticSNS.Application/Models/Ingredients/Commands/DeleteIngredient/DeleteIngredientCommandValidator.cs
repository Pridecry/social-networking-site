using FluentValidation;

namespace DieteticSNS.Application.Models.Ingredients.Commands.DeleteIngredient
{
    public class DeleteIngredientCommandValidator : AbstractValidator<DeleteIngredientCommand>
    {
        public DeleteIngredientCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
