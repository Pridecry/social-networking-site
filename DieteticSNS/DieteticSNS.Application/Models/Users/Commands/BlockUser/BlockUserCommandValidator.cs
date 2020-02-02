using FluentValidation;

namespace DieteticSNS.Application.Models.Users.Commands.BlockUser
{
    public class BlockUserCommandValidator : AbstractValidator<BlockUserCommand>
    {
        public BlockUserCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
