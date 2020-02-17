using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DieteticSNS.Application.Models.Countries.Commands.CreateCountry;
using DieteticSNS.Application.Tests.Infrastructure;
using DieteticSNS.Persistence;
using FluentValidation;
using Shouldly;
using Xunit;

namespace DieteticSNS.Application.Tests.Models.Countries.Command
{
    [Collection("ServicesTestCollection")]
    public class CreateCountryCommandTest
    {
        private readonly DieteticSNSDbContext _context;
        private readonly IMapper _mapper;

        public CreateCountryCommandTest(ServicesFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task Create_Country_Should_Add_Country_To_Database()
        {
            var command = new CreateCountryCommand
            {
                Name = "Poland"
            };

            var commandHandler = new CreateCountryCommandHandler(_context, _mapper);

            await commandHandler.Handle(command, CancellationToken.None);

            var result = _context.Countries
                .Where(x => x.Name.Equals(command.Name))
                .FirstOrDefault();

            result.ShouldNotBeNull();
        }
    }
}
