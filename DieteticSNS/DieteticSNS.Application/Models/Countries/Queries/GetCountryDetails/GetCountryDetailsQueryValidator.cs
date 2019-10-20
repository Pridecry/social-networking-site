using FluentValidation;

namespace DieteticSNS.Application.Models.Countries.Queries.GetCountryDetails
{
    public class GetCountryDetailsQueryValidator : AbstractValidator<GetCountryDetailsQuery>
    {
        public GetCountryDetailsQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
