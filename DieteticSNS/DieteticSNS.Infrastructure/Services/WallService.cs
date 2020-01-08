using System.Threading.Tasks;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Infrastructure.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace DieteticSNS.Infrastructure.Services
{
    public class WallService : IWallService
    {
        private readonly IHubContext<WallHub> _hubContext;

        public WallService(IHubContext<WallHub> wallHub)
        {
            _hubContext = wallHub;
        }

        public async Task SendCommentLike(int userId, int likeId, int commentId)
        {
            await _hubContext.Clients.User(userId.ToString()).SendAsync("ReceiveCommentLike", likeId, commentId);
        }

        public async Task SendPostLike(int userId, int likeId, int postId)
        {
            await _hubContext.Clients.User(userId.ToString()).SendAsync("ReceivePostLike", likeId, postId);
        }

        public async Task SendPostComment(int userId, int commentId, int postId, string content)
        {
            await _hubContext.Clients.User(userId.ToString()).SendAsync("ReceivePostComment", commentId, postId, content);
        }
    }
}
