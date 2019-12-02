using MediatR;

namespace DieteticSNS.Application.Models.Likes.Commands.CreateCommentLike
{
    public class CreateCommentLikeCommand : IRequest
    {
        public int CommentId { get; set; }
    }
}
