using MediatR;

namespace DieteticSNS.Application.Models.Followings.Commands.UnfollowUser
{
    public class UnfollowUserCommand : IRequest
    {
        public int UserId { get; set; }
        public int FollowerId { get; set; }
    }
}
