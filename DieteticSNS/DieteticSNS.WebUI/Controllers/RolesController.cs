using System.Threading.Tasks;
using DieteticSNS.Application.Models.Roles.Commands.CreateRole;
using DieteticSNS.Application.Models.Roles.Commands.DeleteRole;
using DieteticSNS.Application.Models.Roles.Commands.UpdateRole;
using DieteticSNS.Application.Models.Roles.Queries.GetRoleDetails;
using DieteticSNS.Application.Models.Roles.Queries.GetRoleList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DieteticSNS.WebUI.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class RolesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<RoleListVm>> GetRoleList()
        {
            return View(await Mediator.Send(new GetRoleListQuery()));
        }

        [HttpGet]
        public async Task<ActionResult<RoleDetailsVm>> Get(int id)
        {
            return View(await Mediator.Send(new GetRoleDetailsQuery { Id = id }));
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View(new CreateRoleCommand());
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await Mediator.Send(command);

            return RedirectToAction(nameof(GetRoleList));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRole(int id)
        {
            var details = await Mediator.Send(new GetRoleDetailsQuery { Id = id });

            var command = Mapper.Map<UpdateRoleCommand>(details);

            return View(command);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await Mediator.Send(command);

            return RedirectToAction(nameof(GetRoleList));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await Mediator.Send(new DeleteRoleCommand { Id = id });

            return RedirectToAction(nameof(GetRoleList));
        }
    }
}
