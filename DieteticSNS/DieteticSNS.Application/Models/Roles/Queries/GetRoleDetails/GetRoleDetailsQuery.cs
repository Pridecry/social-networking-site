using MediatR;

namespace DieteticSNS.Application.Models.Roles.Queries.GetRoleDetails
{
    public class GetRoleDetailsQuery : IRequest<RoleDetailsVm>
    {
        public int Id { get; set; }
    }
}
