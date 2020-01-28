using DieteticSNS.Application.Common.Validators;
using FluentValidation;

namespace DieteticSNS.Application.Models.Account.Commands.UpdateAccount
{
    public class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand>
    {
        public UpdateAccountCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Avatar).IsImage().When(x => x.Avatar != null);
        }
    }
}
