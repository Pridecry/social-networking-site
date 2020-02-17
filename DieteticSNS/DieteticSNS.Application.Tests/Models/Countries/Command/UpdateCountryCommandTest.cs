using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DieteticSNS.Application.Common.Exceptions;
using DieteticSNS.Application.Models.Countries.Commands.UpdateCountry;
using DieteticSNS.Application.Tests.Infrastructure;
using DieteticSNS.Persistence;
using Shouldly;
using Xunit;

namespace DieteticSNS.Application.Tests.Models.Countries.Command
{
    [Collection("ServicesTestCollection")]
    public class UpdateCountryCommandTest
    {
        private readonly DieteticSNSDbContext _context;
        private readonly IMapper _mapper;

        public UpdateCountryCommandTest(ServicesFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task Update_Country_Should_Edit_Country_In_Database()
        {
            var command = new UpdateCountryCommand
            {
                Id = 2,
                Name = "Poland"
            };

            var commandHandler = new UpdateCountryCommandHandler(_context, _mapper);

            await commandHandler.Handle(command, CancellationToken.None);

            var result = _context.Countries
                .Where(x => x.Id.Equals(command.Id))
                .Where(x => x.Name.Equals(command.Name))
                .FirstOrDefault();

            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task Update_Country_With_Wrong_Id_Should_Throw_Exception()
        {
            var command = new UpdateCountryCommand
            {
                Id = -1,
                Name = "Poland"
            };

            var commandHandler = new UpdateCountryCommandHandler(_context, _mapper);

            await commandHandler.Handle(command, CancellationToken.None).ShouldThrowAsync<NotFoundException>();
        }
    }
}
