using MediatR;

namespace DieteticSNS.Application.Models.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQuery : IRequest<UserDetailsVm>
    {
        public int Id { get; set; }
    }
}
