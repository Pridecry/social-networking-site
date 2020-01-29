using System.Collections.Generic;
using MediatR;

namespace DieteticSNS.Application.Models.Users.Commands.AddUserRoles
{
    public class AddUserRolesCommand : IRequest
    {
        public int Id { get; set; }
        public List<RoleDto> UserRoles { get; set; } = new List<RoleDto>();
    }
}
