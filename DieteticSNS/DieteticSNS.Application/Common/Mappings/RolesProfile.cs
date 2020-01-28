using AutoMapper;
using DieteticSNS.Application.Models.Roles.Commands.CreateRole;
using DieteticSNS.Application.Models.Roles.Commands.UpdateRole;
using DieteticSNS.Application.Models.Roles.Queries.GetRoleDetails;
using Microsoft.AspNetCore.Identity;

namespace DieteticSNS.Application.Common.Mappings
{
    public class RolesProfile : Profile
    {
        public RolesProfile()
        {
            CreateMap<UpdateRoleCommand, IdentityRole<int>>();
            CreateMap<CreateRoleCommand, IdentityRole<int>>();

            CreateMap<RoleDetailsVm, UpdateRoleCommand>();
        }
    }
}
