using FluentValidation;

namespace DieteticSNS.Application.Models.Likes.Commands.DeleteLike
{
    public class DeleteLikeCommandValidator : AbstractValidator<DeleteLikeCommand>
    {
        public DeleteLikeCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
