using MediatR;

namespace DieteticSNS.Application.Models.Roles.Commands.UpdateRole
{
    public class UpdateRoleCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
