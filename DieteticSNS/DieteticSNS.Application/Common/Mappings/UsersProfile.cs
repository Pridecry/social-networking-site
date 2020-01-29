using AutoMapper;
using DieteticSNS.Application.Models.Users.Commands.AddUserRoles;
using DieteticSNS.Application.Models.Users.Commands.UpdateUser;
using DieteticSNS.Application.Models.Users.Queries.GetUserDetails;
using DieteticSNS.Application.Models.Users.Queries.GetUserRolesDetails;
using DieteticSNS.Domain.Entities;

namespace DieteticSNS.Application.Common.Mappings
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<UpdateUserCommand, User>();

            CreateMap<UserDetailsVm, UpdateUserCommand>();

            CreateMap<UserRolesDetailsVm, AddUserRolesCommand>();
            CreateMap<Models.Users.Queries.GetUserRolesDetails.RoleDto, Models.Users.Commands.AddUserRoles.RoleDto>();
        }
    }
}   
