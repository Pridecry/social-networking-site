﻿using System.Threading.Tasks;
using DieteticSNS.Application.Models.Followings.Commands.FollowUser;
using DieteticSNS.Application.Models.Followings.Commands.UnfollowUser;
using DieteticSNS.Application.Models.Followings.Queries.GetFollowersList;
using DieteticSNS.Application.Models.Followings.Queries.GetFollowingsList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DieteticSNS.WebUI.Controllers
{
    [Authorize]
    public class FollowingsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> FollowUser(FollowUserCommand command)
        {
            if (!ModelState.IsValid)
            {
                return NoContent();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> UnfollowUser(UnfollowUserCommand command)
        {
            if (!ModelState.IsValid)
            {
                return NoContent();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<FollowersListVm>> GetFollowersList(int id)
        {
            return View(await Mediator.Send(new GetFollowersListQuery { Id = id }));
        }

        [HttpGet]
        public async Task<ActionResult<FollowingsListVm>> GetFollowingsList(int id)
        {
            return View(await Mediator.Send(new GetFollowingsListQuery { Id = id }));
        }
    }
}
