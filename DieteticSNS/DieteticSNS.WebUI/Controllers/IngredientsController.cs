using System.Threading.Tasks;
using DieteticSNS.Application.Models.Ingredients.Commands.CreateIngredient;
using DieteticSNS.Application.Models.Ingredients.Commands.DeleteIngredient;
using DieteticSNS.Application.Models.Ingredients.Commands.UpdateIngredient;
using DieteticSNS.Application.Models.Ingredients.Queries.GetIngredientDetails;
using DieteticSNS.Application.Models.Ingredients.Queries.GetIngredientList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DieteticSNS.WebUI.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class IngredientsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IngredientListVm>> GetIngredientList()
        {
            return View(await Mediator.Send(new GetIngredientListQuery()));
        }

        [HttpGet]
        public async Task<ActionResult<IngredientDetailsVm>> Get(int id)
        {
            return View(await Mediator.Send(new GetIngredientDetailsQuery { Id = id }));
        }

        [HttpGet]
        public IActionResult CreateIngredient()
        {
            ViewBag.Calories = 0;

            return View(new CreateIngredientCommand());
        }

        [HttpPost]
        public async Task<IActionResult> CreateIngredient(CreateIngredientCommand command)
        {
            ViewBag.Calories = (command.Protein ?? 0) * 4 + (command.Carbohydrate ?? 0) * 4 + (command.Fat ?? 0) * 9;

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

            var command = Mapper.Map<UpdateIngredientCommand>(details);

            ViewBag.Calories = (command.Protein ?? 0) * 4 + (command.Carbohydrate ?? 0) * 4 + (command.Fat ?? 0) * 9;

            return View(command);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateIngredient(UpdateIngredientCommand command)
        {
            ViewBag.Calories = (command.Protein ?? 0) * 4 + (command.Carbohydrate ?? 0) * 4 + (command.Fat ?? 0) * 9;

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
