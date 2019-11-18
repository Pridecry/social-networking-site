using DieteticSNS.Application.Common.Validators;
using FluentValidation;

namespace DieteticSNS.Application.Models.Posts.Commands.CreatePost
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Photo).NotEmpty();
            RuleFor(x => x.Photo).IsImage().When(x => x.Photo != null);
        }
    }
}
