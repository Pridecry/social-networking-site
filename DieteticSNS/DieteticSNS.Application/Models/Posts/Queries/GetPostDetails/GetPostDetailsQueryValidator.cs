using FluentValidation;

namespace DieteticSNS.Application.Models.Posts.Queries.GetPostDetails
{
    public class GetPostDetailsQueryValidator : AbstractValidator<GetPostDetailsQuery>
    {
        public GetPostDetailsQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
