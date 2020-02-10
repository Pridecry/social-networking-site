using MediatR;

namespace DieteticSNS.Application.Models.Notifications.Queries.GetUnreadNotificationList
{
    public class GetUnreadNotificationListQuery : IRequest<UnreadNotificationListVm>
    {
    }
}
