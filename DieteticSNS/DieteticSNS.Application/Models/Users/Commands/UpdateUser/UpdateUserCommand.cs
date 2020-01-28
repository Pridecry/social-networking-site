using MediatR;

namespace DieteticSNS.Application.Models.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
