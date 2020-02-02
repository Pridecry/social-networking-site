using FluentValidation;

namespace DieteticSNS.Application.Models.Reports.Commands.DeletePostReports
{
    public class DeletePostReportsCommandValidator : AbstractValidator<DeletePostReportsCommand>
    {
        public DeletePostReportsCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
