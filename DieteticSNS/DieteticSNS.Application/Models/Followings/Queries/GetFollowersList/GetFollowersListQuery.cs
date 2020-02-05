using MediatR;

namespace DieteticSNS.Application.Models.Followings.Queries.GetFollowersList
{
    public class GetFollowersListQuery : IRequest<FollowersListVm>
    {
        public int Id { get; set; }
    }
}
