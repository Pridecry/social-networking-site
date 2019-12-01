using FluentValidation;

namespace DieteticSNS.Application.Models.Likes.Commands.CreatePostLike
{
    public class CreatePostLikeCommandValidator : AbstractValidator<CreatePostLikeCommand>
    {
        public CreatePostLikeCommandValidator()
        {
            RuleFor(x => x.PostId).NotEmpty();
        }
    }
}
