using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DieteticSNS.Application.Common.Exceptions;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;

namespace DieteticSNS.Application.Models.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IDieteticSNSDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _hostingEnvironment;

        public UpdateUserCommandHandler(IDieteticSNSDbContext context, IMapper mapper, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            if (request.Photo != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, @"img\uploads");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + request.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                await request.Photo.CopyToAsync(new FileStream(filePath, FileMode.Create));

                if (entity.ProfilePicURL != null)
                {
                    File.Delete(Path.Combine(uploadsFolder, entity.ProfilePicURL));
                }

                entity.ProfilePicURL = uniqueFileName;
            }

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
