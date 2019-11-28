using System.Threading.Tasks;
using DieteticSNS.Application.Models.Comments.Commands.CreatePostComment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DieteticSNS.WebUI.Controllers
{
    [Authorize]
    public class CommentsController : BaseController
    {
        //[HttpGet]
        //public async Task<ActionResult<CommentListVm>> GetCommentList()
        //{
        //    ViewBag.CommentList = await Mediator.Send(new GetCommentListQuery());

        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreatePostCommentCommand createPostCommentCommand)
        {
            if (!ModelState.IsValid)
            {
                return NoContent();
            }

            await Mediator.Send(createPostCommentCommand);

            return NoContent();
        }

        //[HttpPost]
        //public async Task<IActionResult> UpdateComment(UpdateCommentCommand command)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return NoContent();
        //    }

        //    await Mediator.Send(command);

        //    return NoContent();
        //}

        //[HttpPost]
        //public async Task<IActionResult> DeleteComment(int id)
        //{
        //    await Mediator.Send(new DeleteCommentCommand { Id = id });

        //    return NoContent();
        //}
    }
}
