using MediatR;

namespace DieteticSNS.Application.Models.Posts.Queries.GetPostsList
{
    public class GetPostListQuery : IRequest<PostListVm>
    {
    }
}
