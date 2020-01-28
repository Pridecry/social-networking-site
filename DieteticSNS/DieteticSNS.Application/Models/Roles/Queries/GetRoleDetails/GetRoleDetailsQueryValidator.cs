using FluentValidation;

namespace DieteticSNS.Application.Models.Roles.Queries.GetRoleDetails
{
    public class GetRoleDetailsQueryValidator : AbstractValidator<GetRoleDetailsQuery>
    {
        public GetRoleDetailsQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
