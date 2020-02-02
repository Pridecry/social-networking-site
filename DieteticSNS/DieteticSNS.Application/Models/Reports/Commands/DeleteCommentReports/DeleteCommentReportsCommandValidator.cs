using FluentValidation;

namespace DieteticSNS.Application.Models.Reports.Commands.DeleteCommentReports
{
    public class DeleteCommentReportsCommandValidator : AbstractValidator<DeleteCommentReportsCommand>
    {
        public DeleteCommentReportsCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
