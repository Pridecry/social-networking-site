using FluentValidation;

namespace DieteticSNS.Application.Models.Account.Queries.GetUserDetails
{
    public class GetAccountDetailsQueryValidator : AbstractValidator<GetAccountDetailsQuery>
    {
        public GetAccountDetailsQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
