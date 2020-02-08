using AutoMapper;
using DieteticSNS.Application.Models.Notifications.Commands.CreateNotification;
using DieteticSNS.Domain.Entities;

namespace DieteticSNS.Application.Common.Mappings
{
    public class NotificationsProfile : Profile
    {
        public NotificationsProfile()
        {
            CreateMap<CreateNotificationCommand, Notification>();
        }
    }
}
