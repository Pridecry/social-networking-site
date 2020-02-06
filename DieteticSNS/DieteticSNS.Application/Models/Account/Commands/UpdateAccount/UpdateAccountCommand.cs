using System;
using DieteticSNS.Domain.Enumerations;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace DieteticSNS.Application.Models.Account.Commands.UpdateAccount
{
    public class UpdateAccountCommand : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender? Gender { get; set; }
        public IFormFile Avatar { get; set; }
        public int? CountryId { get; set; }
    }
}
