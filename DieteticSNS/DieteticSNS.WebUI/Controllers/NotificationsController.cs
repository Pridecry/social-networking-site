using System.Threading.Tasks;
using DieteticSNS.Application.Models.Notifications.Commands.CreateNotification;
using DieteticSNS.Application.Models.Notifications.Commands.DeleteAllNotifications;
using DieteticSNS.Application.Models.Notifications.Commands.DeleteNotification;
using DieteticSNS.Application.Models.Notifications.Queries.GetNotificationList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DieteticSNS.WebUI.Controllers
{
    [Authorize]
    public class NotificationsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<NotificationListVm>> GetNotificationList()
        {
            return View(await Mediator.Send(new GetNotificationListQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            await Mediator.Send(new DeleteNotificationCommand { Id = id });

            return RedirectToAction(nameof(GetNotificationList));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAllNotifications()
        {
            await Mediator.Send(new DeleteAllNotificationsCommand());

            return RedirectToAction(nameof(GetNotificationList));
        }
    }
}
