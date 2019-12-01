using System.Threading.Tasks;
using DieteticSNS.Application.Models.Comments.Commands.CreatePostComment;
using DieteticSNS.Application.Models.Comments.Commands.DeleteComment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DieteticSNS.WebUI.Controllers
{
    [Authorize]
    public class CommentsController : BaseController
    {
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

        [HttpPost]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await Mediator.Send(new DeleteCommentCommand { Id = id });

            return NoContent();
        }
    }
}
