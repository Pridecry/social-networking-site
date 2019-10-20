using MediatR;

namespace DieteticSNS.Application.Models.Countries.Queries.GetCountryDetails
{
    public class GetCountryDetailsQuery : IRequest<CountryDetailsVm>
    {
        public int Id { get; set; }
    }
}
