using FluentValidation;

namespace DieteticSNS.Application.Models.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommandValidator : AbstractValidator<DeleteCommentCommand>
    {
        public DeleteCommentCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
