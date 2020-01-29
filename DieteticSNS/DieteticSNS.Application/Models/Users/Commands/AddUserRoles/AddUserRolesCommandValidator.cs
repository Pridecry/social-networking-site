using FluentValidation;

namespace DieteticSNS.Application.Models.Users.Commands.AddUserRoles
{
    public class AddUserRolesCommandValidator : AbstractValidator<AddUserRolesCommand>
    {
        public AddUserRolesCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
