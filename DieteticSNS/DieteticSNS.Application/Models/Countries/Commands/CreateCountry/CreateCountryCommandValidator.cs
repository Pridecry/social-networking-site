using FluentValidation;

namespace DieteticSNS.Application.Models.Countries.Commands.CreateCountry
{
    public class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommand>
    {
        public CreateCountryCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
