using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DieteticSNS.Application.Common.Exceptions;
using DieteticSNS.Application.Models.Countries.Commands.DeleteCountry;
using DieteticSNS.Application.Tests.Infrastructure;
using DieteticSNS.Persistence;
using Shouldly;
using Xunit;

namespace DieteticSNS.Application.Tests.Models.Countries.Command
{
    [Collection("ServicesTestCollection")]
    public class DeleteCountryCommandTest
    {
        private readonly DieteticSNSDbContext _context;

        public DeleteCountryCommandTest(ServicesFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public async Task Delete_Country_Should_Remove_Country_From_Database()
        {
            var command = new DeleteCountryCommand
            {
                Id = 1
            };

            var commandHandler = new DeleteCountryCommandHandler(_context);

            await commandHandler.Handle(command, CancellationToken.None);

            var result = _context.Countries
                .Where(x => x.Id.Equals(command.Id))
                .FirstOrDefault();

            result.ShouldBeNull();
        }

        [Fact]
        public async Task Delete_Country_With_Wrong_Id_Should_Throw_Exception()
        {
            var command = new DeleteCountryCommand
            {
                Id = -1
            };

            var commandHandler = new DeleteCountryCommandHandler(_context);

            await commandHandler.Handle(command, CancellationToken.None).ShouldThrowAsync<NotFoundException>();
        }
    }
}
