using System;
using DieteticSNS.Domain.Enumerations;

namespace DieteticSNS.Application.Models.Users.Queries.GetUserDetails
{
    public class UserDetailsVm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string ProfilePicURL { get; set; }
        public int? CountryId { get; set; }
    }
}
