using DieteticSNS.Domain.Enumerations;
using MediatR;

namespace DieteticSNS.Application.Models.Notifications.Commands.CreateNotification
{
    public class CreateNotificationCommand : IRequest
    {
        public int UserId { get; set; }
        public int RecipientId { get; set; }
        public NotificationType NotificationType { get; set; }

    }
}
