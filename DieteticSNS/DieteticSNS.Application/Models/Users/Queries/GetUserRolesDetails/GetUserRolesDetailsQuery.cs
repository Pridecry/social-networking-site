using MediatR;

namespace DieteticSNS.Application.Models.Users.Queries.GetUserRolesDetails
{
    public class GetUserRolesDetailsQuery : IRequest<UserRolesDetailsVm>
    {
        public int UserId { get; set; }
    }
}
