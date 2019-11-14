using MediatR;

namespace DieteticSNS.Application.Models.Users.Commands.DeleteAvatar
{
    public class DeleteAvatarCommand : IRequest
    {
        public int Id { get; set; }
    }
}
