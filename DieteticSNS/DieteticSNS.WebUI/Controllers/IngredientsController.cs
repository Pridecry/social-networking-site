using System.Threading.Tasks;
using DieteticSNS.Application.Models.Ingredients.Queries.GetIngredientsList;
using Microsoft.AspNetCore.Mvc;

namespace DieteticSNS.WebUI.Controllers
{
    public class IngredientsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IngredientListModel>> IngredientList()
        {
            return View(await Mediator.Send(new GetIngredientListQuery()));
        }
    }
}
