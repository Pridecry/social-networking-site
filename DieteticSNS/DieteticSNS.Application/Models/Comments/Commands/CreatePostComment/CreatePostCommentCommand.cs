using MediatR;

namespace DieteticSNS.Application.Models.Comments.Commands.CreatePostComment
{
    public class CreatePostCommentCommand : IRequest
    {
        public int PostId { get; set; }
        public string Content { get; set; }
    }
}
