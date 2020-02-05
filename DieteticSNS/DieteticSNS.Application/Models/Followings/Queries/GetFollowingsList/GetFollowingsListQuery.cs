using MediatR;

namespace DieteticSNS.Application.Models.Followings.Queries.GetFollowingsList
{
    public class GetFollowingsListQuery : IRequest<FollowingsListVm>
    {
        public int Id { get; set; }
    }
}
