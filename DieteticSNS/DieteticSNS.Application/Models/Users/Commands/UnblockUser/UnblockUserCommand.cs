using MediatR;

namespace DieteticSNS.Application.Models.Users.Commands.UnblockUser
{
    public class UnblockUserCommand : IRequest
    {
        public int Id { get; set; }
    }
}
