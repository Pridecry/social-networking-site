using FluentValidation;

namespace DieteticSNS.Application.Models.Comments.Commands.CreatePostComment
{
    public class CreatePostCommentCommandValidator : AbstractValidator<CreatePostCommentCommand>
    {
        public CreatePostCommentCommandValidator()
        {
            RuleFor(x => x.PostId).NotEmpty();
            RuleFor(x => x.Content).NotEmpty();
        }
    }
}
