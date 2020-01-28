using MediatR;

namespace DieteticSNS.Application.Models.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public int Id { get; set; }
    }
}
