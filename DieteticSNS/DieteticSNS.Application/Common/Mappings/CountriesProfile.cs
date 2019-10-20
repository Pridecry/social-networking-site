using AutoMapper;
using DieteticSNS.Application.Models.Countries.Commands.CreateCountry;
using DieteticSNS.Application.Models.Countries.Commands.UpdateCountry;
using DieteticSNS.Application.Models.Countries.Queries.GetCountryDetails;
using DieteticSNS.Domain.Entities;

namespace DieteticSNS.Application.Common.Mappings
{
    public class CountriesProfile : Profile
    {
        public CountriesProfile()
        {
            CreateMap<UpdateCountryCommand, Country>();
            CreateMap<CreateCountryCommand, Country>();

            CreateMap<CountryDetailsVm, UpdateCountryCommand>();
        }
    }
}
