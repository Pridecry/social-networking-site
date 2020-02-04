using FluentValidation;

namespace DieteticSNS.Application.Models.Users.Queries.GetUserProfile
{
    public class GetUserProfileQueryValidator : AbstractValidator<GetUserProfileQuery>
    {
        public GetUserProfileQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
