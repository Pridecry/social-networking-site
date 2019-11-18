using MediatR;

namespace DieteticSNS.Application.Models.Posts.Commands.DeletePost
{
    public class DeletePostCommand : IRequest
    {
        public int Id { get; set; }
    }
}
