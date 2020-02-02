using MediatR;

namespace DieteticSNS.Application.Models.Users.Commands.BlockUser
{
    public class BlockUserCommand : IRequest
    {
        public int Id { get; set; }
    }
}
