using System.Threading.Tasks;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Infrastructure.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace DieteticSNS.Infrastructure.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationService(IHubContext<NotificationHub> notificationHub)
        {
            _hubContext = notificationHub;
        }

        public async Task SendMessage(int userId, string message)
        {
            await _hubContext.Clients.User(userId.ToString()).SendAsync("ReceiveMessage", message);
        }
    }
} 
