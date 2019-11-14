using FluentValidation;

namespace DieteticSNS.Application.Models.Users.Commands.DeleteAvatar
{
    public class DeleteAvatarCommandValidator : AbstractValidator<DeleteAvatarCommand>
    {
        public DeleteAvatarCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
