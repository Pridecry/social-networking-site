using MediatR;

namespace DieteticSNS.Application.Models.Notifications.Commands.DeleteNotification
{
    public class DeleteNotificationCommand : IRequest
    {
        public int Id { get; set; }
    }
}
