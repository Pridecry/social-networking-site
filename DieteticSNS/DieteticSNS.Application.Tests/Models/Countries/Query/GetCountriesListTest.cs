using System.Threading;
using System.Threading.Tasks;
using DieteticSNS.Application.Models.Countries.Queries.GetCountryList;
using DieteticSNS.Application.Tests.Infrastructure;
using Microsoft.Extensions.Configuration;
using Shouldly;
using Xunit;

namespace DieteticSNS.Application.Tests.Models.Countries.Query
{
    [Collection("ServicesTestCollection")]
    public class GetCountriesListTest
    {
        private readonly IConfiguration _configuration;

        public GetCountriesListTest(ServicesFixture fixture)
        {
            _configuration = fixture.Configuration;
        }

        [Fact]
        public async Task Get_Countries_List_Should_Return_Countries_List_From_Database()
        {
            var query = new GetCountryListQuery();
            var queryHandler = new GetCountryListQueryHandler(_configuration);

            var result = await queryHandler.Handle(query, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<CountryListVm>();
        }
    }
}
