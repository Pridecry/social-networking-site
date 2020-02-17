using System.Threading;
using System.Threading.Tasks;
using DieteticSNS.Application.Common.Exceptions;
using DieteticSNS.Application.Models.Countries.Queries.GetCountryDetails;
using DieteticSNS.Application.Tests.Infrastructure;
using Microsoft.Extensions.Configuration;
using Shouldly;
using Xunit;

namespace DieteticSNS.Application.Tests.Models.Countries.Query
{
    [Collection("ServicesTestCollection")]
    public class GetCountryDetailsTest
    {
        private readonly IConfiguration _configuration;

        public GetCountryDetailsTest(ServicesFixture fixture)
        {
            _configuration = fixture.Configuration;
        }

        [Fact]
        public async Task Get_Country_Details_Should_Return_Country_Details_From_Database()
        {
            var query = new GetCountryDetailsQuery
            {
                Id = 1
            };

            var queryHandler = new GetCountryDetailsQueryHandler(_configuration);

            var result = await queryHandler.Handle(query, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<CountryDetailsVm>();
        }

        [Fact]
        public async Task Get_Country_Details_With_Wrong_Id_Should_Throw_Exception()
        {
            var query = new GetCountryDetailsQuery
            {
                Id = -1
            };

            var queryHandler = new GetCountryDetailsQueryHandler(_configuration);

            await queryHandler.Handle(query, CancellationToken.None).ShouldThrowAsync<NotFoundException>();
        }
    }
}
