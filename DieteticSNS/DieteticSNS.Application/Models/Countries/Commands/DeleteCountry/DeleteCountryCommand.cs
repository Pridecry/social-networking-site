using MediatR;

namespace DieteticSNS.Application.Models.Countries.Commands.DeleteCountry
{
    public class DeleteCountryCommand : IRequest
    {
        public int Id { get; set; }
    }
}
