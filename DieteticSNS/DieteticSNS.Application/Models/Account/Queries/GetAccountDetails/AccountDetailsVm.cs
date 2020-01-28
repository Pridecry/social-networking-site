using System;
using DieteticSNS.Domain.Enumerations;

namespace DieteticSNS.Application.Models.Account.Queries.GetUserDetails
{
    public class AccountDetailsVm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender? Gender { get; set; }
        public string AvatarPath { get; set; }
        public int? CountryId { get; set; }
    }
}
