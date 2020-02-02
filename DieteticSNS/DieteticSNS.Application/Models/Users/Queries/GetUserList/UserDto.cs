using System;
using DieteticSNS.Domain.Enumerations;

namespace DieteticSNS.Application.Models.Users.Queries.GetUserList
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender? Gender { get; set; }
        public string AvatarPath { get; set; }
        public int? CountryId { get; set; }
        public bool IsBlocked { get; set; }
    }
}
