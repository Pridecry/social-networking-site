using System;
using System.Collections.Generic;
using DieteticSNS.Domain.Enumerations;

namespace DieteticSNS.Application.Models.Users.Queries.GetUserProfile
{
    public class UserProfileVm
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender? Gender { get; set; }
        public string AvatarPath { get; set; }
        public int? CountryId { get; set; }
        public int FollowersCount { get; set; }
        public int FollowingsCount { get; set; }

        public IList<ProfilePostDto> Posts { get; set; } = new List<ProfilePostDto>();
    }
}
