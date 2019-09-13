using System.Collections.Generic;
using System.Threading.Tasks;
using DieteticSNS.Application.Models.Ingredients.Commands.CreateIngredient;
using DieteticSNS.Application.Models.Ingredients.Commands.DeleteIngredient;
using DieteticSNS.Application.Models.Ingredients.Commands.UpdateIngredient;
using DieteticSNS.Application.Models.Ingredients.Queries.GetIngredientsList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DieteticSNS.WebAPI.Controllers
{
    public class IngredientsController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IngredientsModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetIngredientsListQuery()));
        }

        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<CustomerDetailModel>> Get(string id)
        //{
        //    return Ok(await Mediator.Send(new GetCustomerDetailQuery { Id = id }));
        //}

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateIngredient(CreateIngredientCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, UpdateIngredientCommand command)
        {
            command.Id = id;
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute]DeleteIngredientCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
