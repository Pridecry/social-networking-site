using FluentValidation;

namespace DieteticSNS.Application.Models.Users.Commands.UnblockUser
{
    public class UnblockUserCommandValidator : AbstractValidator<UnblockUserCommand>
    {
        public UnblockUserCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
