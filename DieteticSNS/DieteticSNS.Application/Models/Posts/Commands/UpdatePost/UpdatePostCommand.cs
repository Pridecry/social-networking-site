using MediatR;

namespace DieteticSNS.Application.Models.Posts.Commands.UpdatePost
{
    public class UpdatePostCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
