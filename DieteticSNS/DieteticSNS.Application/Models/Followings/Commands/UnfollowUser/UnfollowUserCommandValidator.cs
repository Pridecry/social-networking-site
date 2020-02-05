using FluentValidation;

namespace DieteticSNS.Application.Models.Followings.Commands.UnfollowUser
{
    public class UnfollowUserCommandValidator : AbstractValidator<UnfollowUserCommand>
    {
        public UnfollowUserCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.FollowerId).NotEmpty();
        }
    }
}
