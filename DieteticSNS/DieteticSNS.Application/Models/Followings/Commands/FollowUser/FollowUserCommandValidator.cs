using FluentValidation;

namespace DieteticSNS.Application.Models.Followings.Commands.FollowUser
{
    public class FollowUserCommandValidator : AbstractValidator<FollowUserCommand>
    {
        public FollowUserCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.FollowerId).NotEmpty();
            RuleFor(x => x.UserId).NotEqual(x => x.FollowerId);
        }
    }
}
