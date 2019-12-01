using MediatR;

namespace DieteticSNS.Application.Models.Likes.Commands.CreatePostLike
{
    public class CreatePostLikeCommand : IRequest
    {
        public int PostId { get; set; }
    }
}
