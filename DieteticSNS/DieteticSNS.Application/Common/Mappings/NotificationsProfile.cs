using AutoMapper;
using DieteticSNS.Application.Models.Notifications.Commands.CreateNotification;
using DieteticSNS.Application.Models.Notifications.Queries.GetUnreadNotificationList;
using DieteticSNS.Domain.Entities;

namespace DieteticSNS.Application.Common.Mappings
{
    public class NotificationsProfile : Profile
    {
        public NotificationsProfile()
        {
            CreateMap<CreateNotificationCommand, Notification>();

            CreateMap<Notification, UnreadNotificationDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(x => x.User.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(x => x.User.LastName))
                .ForMember(dest => dest.AvatarPath, opt => opt.MapFrom(x => x.User.AvatarPath));
        }
    }
}
