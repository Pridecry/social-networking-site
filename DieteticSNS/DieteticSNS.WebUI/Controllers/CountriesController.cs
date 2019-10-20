using System.Threading.Tasks;
using DieteticSNS.Application.Models.Countries.Commands.CreateCountry;
using DieteticSNS.Application.Models.Countries.Commands.DeleteCountry;
using DieteticSNS.Application.Models.Countries.Commands.UpdateCountry;
using DieteticSNS.Application.Models.Countries.Queries.GetCountryDetails;
using DieteticSNS.Application.Models.Countries.Queries.GetCountriesList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DieteticSNS.WebUI.Controllers
{
    [Authorize]
    public class CountriesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<CountryListVm>> GetCountryList()
        {
            return View(await Mediator.Send(new GetCountryListQuery()));
        }

        [HttpGet]
        public async Task<ActionResult<CountryDetailsVm>> Get(int id)
        {
            return View(await Mediator.Send(new GetCountryDetailsQuery { Id = id }));
        }

        [HttpGet]
        public IActionResult CreateCountry()
        {
            return View(new CreateCountryCommand());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCountry(CreateCountryCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await Mediator.Send(command);

            return RedirectToAction(nameof(GetCountryList));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCountry(int id)
        {
            var details = await Mediator.Send(new GetCountryDetailsQuery { Id = id });

            var command = Mapper.Map<UpdateCountryCommand>(details);

            return View(command);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCountry(UpdateCountryCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await Mediator.Send(command);

            return RedirectToAction(nameof(GetCountryList));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            await Mediator.Send(new DeleteCountryCommand { Id = id });

            return RedirectToAction(nameof(GetCountryList));
        }
    }
}
