using System.Linq;
using System.Security.Claims;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace DieteticSNS.WebUI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDieteticSNSDbContext _context;

        private readonly User _user;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor, IDieteticSNSDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;

            var id = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (id != null)
            {
                _user = _context.Users.SingleOrDefault(x => x.Id == int.Parse(id)); 
            }
        }

        public string GetUserId()
        {
            return _user?.Id.ToString();
        }

        public string GetUserFullName()
        {
            return $"{ _user?.FirstName } { _user?.LastName }";
        }

        public int GetUserFollowersCount()
        {
            return _user?.Followers.Count ?? 0;
        }

        public int GetUserFollowingsCount()
        {
            return _user?.Followings.Count ?? 0;
        }

        public int GetUserPostsCount()
        {
            return _user?.Posts.Count ?? 0;
        }

        public int GetUserRecipesCount()
        {
            return _user?.Recipes.Count ?? 0;
        }
    }
}
