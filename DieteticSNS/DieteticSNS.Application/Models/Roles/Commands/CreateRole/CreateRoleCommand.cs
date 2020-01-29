using MediatR;

namespace DieteticSNS.Application.Models.Roles.Commands.CreateRole
{
    public class CreateRoleCommand : IRequest
    {
        public string Name { get; set; }
    }
}
