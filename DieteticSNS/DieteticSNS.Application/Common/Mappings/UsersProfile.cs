using AutoMapper;
using DieteticSNS.Application.Models.Users.Commands.UpdateUser;
using DieteticSNS.Application.Models.Users.Queries.GetUserDetails;
using DieteticSNS.Domain.Entities;

namespace DieteticSNS.Application.Common.Mappings
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<UpdateUserCommand, User>();

            CreateMap<UserDetailsVm, UpdateUserCommand>();
        }
    }
}
