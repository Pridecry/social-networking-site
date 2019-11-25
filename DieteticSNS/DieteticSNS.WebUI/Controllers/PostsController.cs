using System.Threading.Tasks;
using DieteticSNS.Application.Models.Posts.Commands.CreatePost;
using DieteticSNS.Application.Models.Posts.Commands.DeletePost;
using DieteticSNS.Application.Models.Posts.Commands.UpdatePost;
using DieteticSNS.Application.Models.Posts.Queries.GetPostDetails;
using DieteticSNS.Application.Models.Posts.Queries.GetPostsList;
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

            return View();
        }

        [HttpGet]
        public async Task<ActionResult<PostDetailsVm>> Get(int id)
        {
            return View(await Mediator.Send(new GetPostDetailsQuery { Id = id }));
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

        //[HttpGet]
        //public async Task<IActionResult> UpdatePost(int id)
        //{
        //    var details = await Mediator.Send(new GetPostDetailsQuery { Id = id });

        //    var command = Mapper.Map<UpdatePostCommand>(details);

        //    return View(command);
        //}

        [HttpPost]
        public async Task<IActionResult> UpdatePost(UpdatePostCommand command)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(GetPostList));
            }

            await Mediator.Send(command);

            return RedirectToAction(nameof(GetPostList));
        }

        [HttpPost]
        public async Task<NoContentResult> DeletePost(int id)
        {
            await Mediator.Send(new DeletePostCommand { Id = id });

            return NoContent();
        }
    }
}
