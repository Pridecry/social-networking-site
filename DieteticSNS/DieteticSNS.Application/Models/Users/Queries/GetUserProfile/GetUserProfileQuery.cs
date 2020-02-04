using MediatR;

namespace DieteticSNS.Application.Models.Users.Queries.GetUserProfile
{
    public class GetUserProfileQuery : IRequest<UserProfileVm>
    {
        public int Id { get; set; }
    }
}
