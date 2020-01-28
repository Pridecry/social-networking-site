using FluentValidation;

namespace DieteticSNS.Application.Models.Account.Commands.DeleteAvatar
{
    public class DeleteAvatarCommandValidator : AbstractValidator<DeleteAvatarCommand>
    {
        public DeleteAvatarCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
