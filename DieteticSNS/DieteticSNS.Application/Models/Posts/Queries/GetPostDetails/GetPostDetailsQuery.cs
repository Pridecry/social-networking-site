using MediatR;

namespace DieteticSNS.Application.Models.Posts.Queries.GetPostDetails
{
    public class GetPostDetailsQuery : IRequest<PostDetailsVm>
    {
        public int Id { get; set; }
    }
}
