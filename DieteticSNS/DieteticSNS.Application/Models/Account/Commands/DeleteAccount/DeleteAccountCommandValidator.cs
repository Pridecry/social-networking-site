using FluentValidation;

namespace DieteticSNS.Application.Models.Account.Commands.DeleteAccount
{
    public class DeleteAccountCommandValidator : AbstractValidator<DeleteAccountCommand>
    {
        public DeleteAccountCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
