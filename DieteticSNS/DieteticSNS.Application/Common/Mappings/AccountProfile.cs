using AutoMapper;
using DieteticSNS.Application.Models.Account.Commands.UpdateUser;
using DieteticSNS.Application.Models.Account.Queries.GetUserDetails;
using DieteticSNS.Domain.Entities;

namespace DieteticSNS.Application.Common.Mappings
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<UpdateAccountCommand, User>();

            CreateMap<AccountDetailsVm, UpdateAccountCommand>();
        }
    }
}
