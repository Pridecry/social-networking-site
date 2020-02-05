using FluentValidation;

namespace DieteticSNS.Application.Models.Followings.Queries.GetFollowersList
{
    public class GetFollowersListQueryValidator : AbstractValidator<GetFollowersListQuery>
    {
        public GetFollowersListQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
