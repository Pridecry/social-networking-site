using FluentValidation;

namespace DieteticSNS.Application.Models.Notifications.Commands.CreateNotification
{
    public class CreateNotificationCommandValidator : AbstractValidator<CreateNotificationCommand>
    {
        public CreateNotificationCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.RecipientId).NotEmpty();
            RuleFor(x => x.UserId).NotEqual(x => x.RecipientId);
        }
    }
}
