using System.Threading.Tasks;
using DieteticSNS.Application.Models.Posts.Commands.CreatePost;
using DieteticSNS.Application.Models.Posts.Commands.DeletePost;
using DieteticSNS.Application.Models.Posts.Commands.UpdatePost;
using DieteticSNS.Application.Models.Posts.Queries.GetMinifiedPostList;
using DieteticSNS.Application.Models.Posts.Queries.GetPostList;
using DieteticSNS.Application.Models.Users.Queries.GetSuggestedUserList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DieteticSNS.WebUI.Controllers
{
    [Authorize]
    public class PostsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<PostListVm>> GetPostList()
        {
            ViewBag.PostList = await Mediator.Send(new GetPostListQuery());
            ViewBag.SuggestedUserList = await Mediator.Send(new GetSuggestedUserListQuery());

            return View();
        }

        [HttpPost]
        public async Task<PartialViewResult> CreatePost(CreatePostCommand command)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_CreatePost", command);
            }

            await Mediator.Send(command);

            ModelState.Clear();
            return PartialView("_CreatePost");
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePost(UpdatePostCommand updatePostCommand)
        {
            if (!ModelState.IsValid)
            {
                return NoContent();
            }

            await Mediator.Send(updatePostCommand);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await Mediator.Send(new DeletePostCommand { Id = id });

            return NoContent();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<MinifiedPostListVm>> GetMinifiedPostList()
        {
            return View(await Mediator.Send(new GetMinifiedPostListQuery()));
        }
    }
}
