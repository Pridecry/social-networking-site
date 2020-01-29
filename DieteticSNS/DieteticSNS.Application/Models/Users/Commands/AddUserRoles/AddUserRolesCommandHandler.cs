using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DieteticSNS.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DieteticSNS.Application.Models.Users.Commands.AddUserRoles
{
    public class AddUserRolesCommandHandler : IRequestHandler<AddUserRolesCommand>
    {
        private readonly UserManager<User> _userManager;

        public AddUserRolesCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(AddUserRolesCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());

            var selectedRoles = new List<string>();
            var unselectedRoles = new List<string>();

            foreach (var role in request.UserRoles)
            {
                if (role.IsSelected)
                {
                    if (!await _userManager.IsInRoleAsync(user, role.RoleName))
                    {
                        selectedRoles.Add(role.RoleName);
                    }
                }
                else
                {
                    if (await _userManager.IsInRoleAsync(user, role.RoleName))
                    {
                        unselectedRoles.Add(role.RoleName);
                    }
                }
            }

            await _userManager.AddToRolesAsync(user, selectedRoles);
            await _userManager.RemoveFromRolesAsync(user, unselectedRoles);

            return Unit.Value;
        }
    }
}
