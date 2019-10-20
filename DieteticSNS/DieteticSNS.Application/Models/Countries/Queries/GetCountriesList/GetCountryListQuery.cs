using MediatR;

namespace DieteticSNS.Application.Models.Countries.Queries.GetCountriesList
{
    public class GetCountryListQuery : IRequest<CountryListVm>
    {
    }
}
