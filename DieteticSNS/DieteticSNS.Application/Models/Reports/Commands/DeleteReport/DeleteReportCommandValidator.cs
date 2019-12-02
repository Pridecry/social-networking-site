using FluentValidation;

namespace DieteticSNS.Application.Models.Reports.Commands.DeleteReport
{
    public class DeleteReportCommandValidator : AbstractValidator<DeleteReportCommand>
    {
        public DeleteReportCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
