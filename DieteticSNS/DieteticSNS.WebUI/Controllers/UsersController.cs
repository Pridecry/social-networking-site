using System.Linq;
using System.Threading.Tasks;
using DieteticSNS.Application.Models.Countries.Queries.GetCountryList;
using DieteticSNS.Application.Models.Users.Commands.AddUserRoles;
using DieteticSNS.Application.Models.Users.Commands.BlockUser;
using DieteticSNS.Application.Models.Users.Commands.DeleteUser;
using DieteticSNS.Application.Models.Users.Commands.UnblockUser;
using DieteticSNS.Application.Models.Users.Commands.UpdateUser;
using DieteticSNS.Application.Models.Users.Queries.GetUserDetails;
using DieteticSNS.Application.Models.Users.Queries.GetUserList;
using DieteticSNS.Application.Models.Users.Queries.GetUserRolesDetails;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DieteticSNS.WebUI.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UsersController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<UserListVm>> GetUserList()
        {
            var countryListVm = await Mediator.Send(new GetCountryListQuery());
            ViewBag.Countries = countryListVm.Countries.ToList();

            return View(await Mediator.Send(new GetUserListQuery()));
        }

        [HttpGet]
        public async Task<ActionResult<UserDetailsVm>> Get(int id)
        {
            return View(await Mediator.Send(new GetUserDetailsQuery { Id = id }));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUser(int id)
        {
            var details = await Mediator.Send(new GetUserDetailsQuery { Id = id });

            var command = Mapper.Map<UpdateUserCommand>(details);

            return View(command);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await Mediator.Send(command);

            return RedirectToAction(nameof(GetUserList));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await Mediator.Send(new DeleteUserCommand { Id = id }); 

            return RedirectToAction(nameof(GetUserList));
        }

        [HttpGet]
        public async Task<IActionResult> AddUserRolesAsync(int id)
        {
            var details = await Mediator.Send(new GetUserRolesDetailsQuery { UserId = id });

            var command = Mapper.Map<AddUserRolesCommand>(details);

            return View(command);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserRoles(AddUserRolesCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await Mediator.Send(command);

            return RedirectToAction(nameof(GetUserList));
        }

        [HttpPost]
        public async Task<IActionResult> BlockUser(int id)
        {
            await Mediator.Send(new BlockUserCommand { Id = id });

            return RedirectToAction(nameof(GetUserList));
        }

        [HttpPost]
        public async Task<IActionResult> UnblockUser(int id)
        {
            await Mediator.Send(new UnblockUserCommand { Id = id });

            return RedirectToAction(nameof(GetUserList));
        }
    }
}
