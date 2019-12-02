using System.Threading.Tasks;
using DieteticSNS.Application.Models.Reports.Commands.CreateCommentReport;
using DieteticSNS.Application.Models.Reports.Commands.CreatePostReport;
using DieteticSNS.Application.Models.Reports.Commands.DeleteReport;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DieteticSNS.WebUI.Controllers
{
    [Authorize]
    public class ReportsController : BaseController
    {
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

        [HttpPost]
        public async Task<IActionResult> DeleteReport(int id)
        {
            await Mediator.Send(new DeleteReportCommand { Id = id });

            return NoContent();
        }
    }
}
