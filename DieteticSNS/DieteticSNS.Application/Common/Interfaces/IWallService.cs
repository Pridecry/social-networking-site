using System.Threading.Tasks;

namespace DieteticSNS.Application.Common.Interfaces
{
    public interface IWallService
    {
        Task SendCommentLike(int userId, int likeId, int commentId);
        Task SendPostLike(int userId, int likeId, int postId);
        Task SendPostComment(int userId, int commentId, int postId, string content);
    }
}
