using System.Collections.Generic;
using System.Threading.Tasks;
using DieteticSNS.Application.Models.Ingredients.Commands.CreateIngredient;
using DieteticSNS.Application.Models.Ingredients.Commands.DeleteIngredient;
using DieteticSNS.Application.Models.Ingredients.Commands.UpdateIngredient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DieteticSNS.WebAPI.Controllers
{
    public class IngredientsController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateIngredient([FromBody]CreateIngredientCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody]UpdateIngredientCommand command)
        {
            command.Id = id;
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteIngredientCommand { Id = id });

            return NoContent();
        }
    }
}
