using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DieteticSNS.Application.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DieteticSNS.Application.Models.Roles.Commands.UpdateRole
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand>
    {
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IMapper _mapper;

        public UpdateRoleCommandHandler(RoleManager<IdentityRole<int>> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _roleManager.FindByIdAsync(request.Id.ToString());

            if (entity == null)
            {
                throw new NotFoundException(nameof(IdentityRole), request.Id);
            }

            _mapper.Map(request, entity);
            await _roleManager.UpdateAsync(entity);

            return Unit.Value;
        }
    }
}
