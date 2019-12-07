using System.IO;
using System.Linq;
using System.Security.Claims;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DieteticSNS.WebUI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDieteticSNSDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        private readonly User _user;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor, IDieteticSNSDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _hostingEnvironment = hostingEnvironment;

            var id = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (id != null)
            {
                _user = _context.Users
                    .Include(x => x.Followers)
                    .Include(x => x.Followings)
                    .Include(x => x.Posts)
                    .Include(x => x.Recipes)
                    .SingleOrDefault(x => x.Id == int.Parse(id)); 
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

        public string GetUserAvatarPath()
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, @"img\uploads");
            string fileName = _user?.AvatarPath ?? "";
            string avatarPath = Path.Combine(uploadsFolder, fileName);

            if (_user?.AvatarPath == null || !File.Exists(avatarPath))
            {
                return "~/img/noavatar.jpg";
            }

            return "~/img/uploads/" + _user.AvatarPath;
        }

        public bool HasAvatar()
        {
            if (_user?.AvatarPath != null)
            {
                return true;
            }
            else return false;
        }
    }
}
