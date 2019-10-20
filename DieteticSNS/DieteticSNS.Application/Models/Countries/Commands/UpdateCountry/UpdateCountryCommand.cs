using MediatR;

namespace DieteticSNS.Application.Models.Countries.Commands.UpdateCountry
{
    public class UpdateCountryCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
