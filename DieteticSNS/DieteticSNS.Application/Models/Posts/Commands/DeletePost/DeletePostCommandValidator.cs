using FluentValidation;

namespace DieteticSNS.Application.Models.Posts.Commands.DeletePost
{
    public class DeletePostCommandValidator : AbstractValidator<DeletePostCommand>
    {
        public DeletePostCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
