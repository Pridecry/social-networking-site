using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace DieteticSNS.Infrastructure.Hubs
{
    [Authorize]
    public class NotificationHub : Hub
    {
    }
}
