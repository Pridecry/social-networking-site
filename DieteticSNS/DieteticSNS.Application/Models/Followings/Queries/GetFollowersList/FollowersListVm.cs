using System.Collections.Generic;

namespace DieteticSNS.Application.Models.Followings.Queries.GetFollowersList
{
    public class FollowersListVm
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarPath { get; set; }
        public int FollowersCount { get; set; }
        public int FollowingsCount { get; set; }
        public int PostCount { get; set; }

        public IList<FollowerDto> Followers { get; set; } = new List<FollowerDto>();
    }
}
