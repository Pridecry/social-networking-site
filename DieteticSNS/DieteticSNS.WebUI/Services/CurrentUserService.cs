using System.Linq;
using System.Security.Claims;
using DieteticSNS.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace DieteticSNS.WebUI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDieteticSNSDbContext _context;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor, IDieteticSNSDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public string GetUserId()
        {
            return _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string GetUserFullName()
        {
            var id = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (id == null)
            {
                return string.Empty;
            }

            var user = _context.Users.SingleOrDefault(x => x.Id == int.Parse(id));

            return $"{ user?.FirstName } { user?.LastName }";
        }
    }
}
