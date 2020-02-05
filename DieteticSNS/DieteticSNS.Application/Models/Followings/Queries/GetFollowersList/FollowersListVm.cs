using System.Collections.Generic;

namespace DieteticSNS.Application.Models.Followings.Queries.GetFollowersList
{
    public class FollowersListVm
    {
        public int Id { get; set; }

        public IList<FollowerDto> Followers { get; set; } = new List<FollowerDto>();
    }
}
