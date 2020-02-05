using MediatR;

namespace DieteticSNS.Application.Models.Followings.Commands.FollowUser
{
    public class FollowUserCommand : IRequest
    {
        public int UserId { get; set; }
        public int FollowerId { get; set; }
    }
}
