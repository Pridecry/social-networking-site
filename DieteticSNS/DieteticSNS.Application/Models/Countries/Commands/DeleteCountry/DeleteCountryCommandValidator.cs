using FluentValidation;

namespace DieteticSNS.Application.Models.Countries.Commands.DeleteCountry
{
    public class DeleteCountryCommandValidator : AbstractValidator<DeleteCountryCommand>
    {
        public DeleteCountryCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
