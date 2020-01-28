using System.Threading;
using System.Threading.Tasks;
using DieteticSNS.Application.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DieteticSNS.Application.Models.Roles.Commands.DeleteRole
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand>
    {
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public DeleteRoleCommandHandler(RoleManager<IdentityRole<int>> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<Unit> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _roleManager.FindByIdAsync(request.Id.ToString());

            if (entity == null)
            {
                throw new NotFoundException(nameof(IdentityRole), request.Id);
            }

            await _roleManager.DeleteAsync(entity);

            return Unit.Value;
        }
    }
}
