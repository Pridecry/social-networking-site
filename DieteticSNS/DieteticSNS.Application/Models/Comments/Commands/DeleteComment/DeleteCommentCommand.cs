using MediatR;

namespace DieteticSNS.Application.Models.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommand : IRequest
    {
        public int Id { get; set; }
    }
}
