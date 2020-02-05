using AutoMapper;
using DieteticSNS.Application.Models.Followings.Commands.FollowUser;
using DieteticSNS.Domain.Entities;

namespace DieteticSNS.Application.Common.Mappings
{
    public class FollowingsProfile : Profile
    {
        public FollowingsProfile()
        {
            CreateMap<FollowUserCommand, Following>();
        }
    }
}
