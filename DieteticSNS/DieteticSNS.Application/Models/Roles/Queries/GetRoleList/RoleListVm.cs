using System.Collections.Generic;

namespace DieteticSNS.Application.Models.Roles.Queries.GetRoleList
{
    public class RoleListVm
    {
        public IList<RoleDto> Roles { get; set; } = new List<RoleDto>();
    }
}
