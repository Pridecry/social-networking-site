using System.Threading.Tasks;
using DieteticSNS.Application.Models.Notifications.Queries.GetUnreadNotificationList;

namespace DieteticSNS.Application.Common.Interfaces
{
    public interface INotificationService
    {
        Task SendNotification(UnreadNotificationDto notification);
    }
}
