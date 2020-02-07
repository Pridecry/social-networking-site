using AutoMapper;
using DieteticSNS.Application.Models.Account.Commands.UpdateAccount;
using DieteticSNS.Application.Models.Account.Queries.GetUserDetails;
using DieteticSNS.Application.Models.Account.Queries.GetUserNotificationSettings;
using DieteticSNS.Application.Models.Account.Commands.UpdateNotifications;
using DieteticSNS.Domain.Entities;

namespace DieteticSNS.Application.Common.Mappings
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<UpdateAccountCommand, User>();
            CreateMap<UpdateNotificationsCommand, UserNotificationSettings>();

            CreateMap<AccountDetailsVm, UpdateAccountCommand>();
            CreateMap<UserNotificationSettingsVm, UpdateNotificationsCommand>();
        }
    }
}
