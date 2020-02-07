using MediatR;

namespace DieteticSNS.Application.Models.Account.Queries.GetUserNotificationSettings
{
    public class GetUserNotificationSettingsQuery : IRequest<UserNotificationSettingsVm>
    {
    }
}
