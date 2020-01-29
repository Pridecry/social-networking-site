using FluentValidation;

namespace DieteticSNS.Application.Models.Users.Queries.GetUserRolesDetails
{
    public class GetUserRolesDetailsQueryValidator : AbstractValidator<GetUserRolesDetailsQuery>
    {
        public GetUserRolesDetailsQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
