using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace DieteticSNS.Infrastructure.Hubs
{
    [Authorize]
    public class NotificationHub : Hub
    {
        //public async Task SendMessageToCaller(string user, string message)
        //{
        //    await Clients.Caller.SendAsync("ReceiveMessage", user, message);
        //}
    }
}
