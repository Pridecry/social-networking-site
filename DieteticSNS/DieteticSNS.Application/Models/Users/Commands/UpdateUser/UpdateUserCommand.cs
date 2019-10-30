using System;
using DieteticSNS.Domain.Enumerations;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace DieteticSNS.Application.Models.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender? Gender { get; set; }
        public IFormFile Photo { get; set; }
        public int? CountryId { get; set; }
    }
}
