using System.IO;
using DieteticSNS.Application.Common.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace DieteticSNS.Application.Models.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Avatar).IsImage().When(x => x.Avatar != null);
        }
    }
}
