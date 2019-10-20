using MediatR;

namespace DieteticSNS.Application.Models.Countries.Commands.CreateCountry
{
    public class CreateCountryCommand : IRequest
    {
        public string Name { get; set; }
    }
}
