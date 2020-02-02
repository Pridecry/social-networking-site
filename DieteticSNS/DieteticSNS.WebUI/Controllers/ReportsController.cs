using System.Threading.Tasks;
using DieteticSNS.Application.Models.Comments.Commands.DeleteComment;
using DieteticSNS.Application.Models.Posts.Commands.DeletePost;
using DieteticSNS.Application.Models.Reports.Commands.CreateCommentReport;
using DieteticSNS.Application.Models.Reports.Commands.CreatePostReport;
using DieteticSNS.Application.Models.Reports.Commands.DeleteCommentReports;
using DieteticSNS.Application.Models.Reports.Commands.DeletePostReports;
using DieteticSNS.Application.Models.Reports.Queries.GetReportList;
using DieteticSNS.Application.Models.Users.Commands.BlockUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DieteticSNS.WebUI.Controllers
{
    [Authorize]
    public class ReportsController : BaseController
    {
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public async Task<ActionResult<ReportListVm>> GetReportList()
        {
            return View(await Mediator.Send(new GetReportListQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePostReport(int id)
        {
            if (!ModelState.IsValid)
            {
                return NoContent();
            }

            await Mediator.Send(new CreatePostReportCommand() { PostId = id });

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCommentReport(int id)
        {
            if (!ModelState.IsValid)
            {
                return NoContent();
            }

            await Mediator.Send(new CreateCommentReportCommand() { CommentId = id });

            return NoContent();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> DeletePostReports(int id)
        {
            await Mediator.Send(new DeletePostReportsCommand { Id = id });

            return RedirectToAction(nameof(GetReportList));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> DeleteCommentReports(int id)
        {
            await Mediator.Send(new DeleteCommentReportsCommand { Id = id });

            return RedirectToAction(nameof(GetReportList));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> BlockUser(int id)
        {
            await Mediator.Send(new BlockUserCommand { Id = id });

            return RedirectToAction(nameof(GetReportList));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await Mediator.Send(new DeletePostCommand { Id = id });

            return RedirectToAction(nameof(GetReportList));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await Mediator.Send(new DeleteCommentCommand { Id = id });

            return RedirectToAction(nameof(GetReportList));
        }
    }
}
