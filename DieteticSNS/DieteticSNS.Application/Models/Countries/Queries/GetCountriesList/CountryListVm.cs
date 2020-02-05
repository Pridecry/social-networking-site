using System.Collections.Generic;

namespace DieteticSNS.Application.Models.Countries.Queries.GetCountryList
{
    public class CountryListVm
    {
        public IList<CountryDto> Countries { get; set; } = new List<CountryDto>();
    }
}
