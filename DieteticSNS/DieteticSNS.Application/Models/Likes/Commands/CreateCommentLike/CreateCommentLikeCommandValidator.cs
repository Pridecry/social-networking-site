using FluentValidation;

namespace DieteticSNS.Application.Models.Likes.Commands.CreateCommentLike
{
    public class CreateCommentLikeCommandValidator : AbstractValidator<CreateCommentLikeCommand>
    {
        public CreateCommentLikeCommandValidator()
        {
            RuleFor(x => x.CommentId).NotEmpty();
        }
    }
}
