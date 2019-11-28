using MediatR;

namespace DieteticSNS.Application.Models.Countries.Queries.GetCountryList
{
    public class GetCountryListQuery : IRequest<CountryListVm>
    {
    }
}
