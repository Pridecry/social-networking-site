using FluentValidation;

namespace DieteticSNS.Application.Models.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQueryValidator : AbstractValidator<GetUserDetailsQuery>
    {
        public GetUserDetailsQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
