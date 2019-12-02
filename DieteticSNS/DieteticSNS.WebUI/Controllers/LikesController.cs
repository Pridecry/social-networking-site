using System.Threading.Tasks;
using DieteticSNS.Application.Models.Likes.Commands.CreateCommentLike;
using DieteticSNS.Application.Models.Likes.Commands.CreatePostLike;
using DieteticSNS.Application.Models.Likes.Commands.DeleteLike;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DieteticSNS.WebUI.Controllers
{
    [Authorize]
    public class LikesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreatePostLike(int id)
        {
            if (!ModelState.IsValid)
            {
                return NoContent();
            }

            await Mediator.Send(new CreatePostLikeCommand() { PostId = id });

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCommentLike(int id)
        {
            if (!ModelState.IsValid)
            {
                return NoContent();
            }

            await Mediator.Send(new CreateCommentLikeCommand() { CommentId = id });

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteLike(int id)
        {
            await Mediator.Send(new DeleteLikeCommand { Id = id });

            return NoContent();
        }
    }
}
