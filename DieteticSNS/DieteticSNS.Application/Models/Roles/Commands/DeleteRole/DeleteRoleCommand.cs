using MediatR;

namespace DieteticSNS.Application.Models.Roles.Commands.DeleteRole
{
    public class DeleteRoleCommand : IRequest
    {
        public int Id { get; set; }
    }
}
