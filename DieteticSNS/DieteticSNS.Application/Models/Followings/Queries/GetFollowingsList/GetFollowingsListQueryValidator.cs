using FluentValidation;

namespace DieteticSNS.Application.Models.Followings.Queries.GetFollowingsList
{
    public class GetFollowingsListQueryValidator : AbstractValidator<GetFollowingsListQuery>
    {
        public GetFollowingsListQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
