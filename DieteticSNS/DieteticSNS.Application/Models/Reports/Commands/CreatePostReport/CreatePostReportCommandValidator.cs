using FluentValidation;

namespace DieteticSNS.Application.Models.Reports.Commands.CreatePostReport
{
    public class CreatePostReportCommandValidator : AbstractValidator<CreatePostReportCommand>
    {
        public CreatePostReportCommandValidator()
        {
            RuleFor(x => x.PostId).NotEmpty();
        }
    }
}
