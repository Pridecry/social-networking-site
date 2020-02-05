using System.Collections.Generic;

namespace DieteticSNS.Application.Models.Followings.Queries.GetFollowingsList
{
    public class FollowingsListVm
    {
        public int Id { get; set; }

        public IList<FollowingDto> Followings { get; set; } = new List<FollowingDto>();
    }
}
