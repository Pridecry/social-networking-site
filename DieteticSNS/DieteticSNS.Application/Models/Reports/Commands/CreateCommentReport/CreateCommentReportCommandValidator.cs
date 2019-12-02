using FluentValidation;

namespace DieteticSNS.Application.Models.Reports.Commands.CreateCommentReport
{
    public class CreateCommentReportCommandValidator : AbstractValidator<CreateCommentReportCommand>
    {
        public CreateCommentReportCommandValidator()
        {
            RuleFor(x => x.CommentId).NotEmpty();
        }
    }
}
