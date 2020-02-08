using FluentValidation;

namespace DieteticSNS.Application.Models.Notifications.Commands.DeleteNotification
{
    public class DeleteNotificationCommandValidator : AbstractValidator<DeleteNotificationCommand>
    {
        public DeleteNotificationCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
