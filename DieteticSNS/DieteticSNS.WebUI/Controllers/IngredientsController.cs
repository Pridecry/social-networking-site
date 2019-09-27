using System.Threading.Tasks;
using DieteticSNS.Application.Models.Ingredients.Commands.CreateIngredient;
using DieteticSNS.Application.Models.Ingredients.Commands.DeleteIngredient;
using DieteticSNS.Application.Models.Ingredients.Commands.UpdateIngredient;
using DieteticSNS.Application.Models.Ingredients.Queries.GetIngredientDetails;
using DieteticSNS.Application.Models.Ingredients.Queries.GetIngredientsList;
using Microsoft.AspNetCore.Mvc;

namespace DieteticSNS.WebUI.Controllers
{
    public class IngredientsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IngredientListModel>> GetIngredientList()
        {
            return View(await Mediator.Send(new GetIngredientListQuery()));
        }

        [HttpGet]
        public async Task<ActionResult<IngredientDetailsModel>> Get(int id)
        {
            return View(await Mediator.Send(new GetIngredientDetailsQuery { Id = id }));
        }

        [HttpGet]
        public IActionResult CreateIngredient()
        {
            return View(new CreateIngredientCommand());
        }

        [HttpPost]
        public async Task<IActionResult> CreateIngredient(CreateIngredientCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await Mediator.Send(command);

            return RedirectToAction(nameof(GetIngredientList));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateIngredient(int id)
        {
            var details = await Mediator.Send(new GetIngredientDetailsQuery { Id = id });

            //todo 
            //map from details to command
            //configure 

            return View(new UpdateIngredientCommand { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateIngredient(UpdateIngredientCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await Mediator.Send(command);

            return RedirectToAction(nameof(GetIngredientList));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteIngredient(int id)
        {
            await Mediator.Send(new DeleteIngredientCommand { Id = id });

            return RedirectToAction(nameof(GetIngredientList));
        }
    }
}
