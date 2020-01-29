using System.Collections.Generic;

namespace DieteticSNS.Application.Models.Users.Queries.GetUserRolesDetails
{
    public class UserRolesDetailsVm
    {
        public List<RoleDto> UserRoles { get; set; } = new List<RoleDto>();
    }
}
