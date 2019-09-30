﻿using System.Threading.Tasks;
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

            //todo 
            //map from details to command
            //configure 
            var command = new UpdateIngredientCommand
            {
                Id = id,
                Name = details.Name,
                Protein = details.Protein,
                Carbohydrate = details.Carbohydrate,
                Fat = details.Fat
            };

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
