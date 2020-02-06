using System.Linq;
using System.Threading.Tasks;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Application.Models.Account.Commands.DeleteAccount;
using DieteticSNS.Application.Models.Account.Commands.DeleteAvatar;
using DieteticSNS.Application.Models.Account.Commands.UpdateAccount;
using DieteticSNS.Application.Models.Account.Queries.GetUserDetails;
using DieteticSNS.Application.Models.Countries.Queries.GetCountryList;
using DieteticSNS.Domain.Entities;
using DieteticSNS.WebUI.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DieteticSNS.WebUI.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IImageService _imageService;
        private readonly ICurrentUserService _userService;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IImageService imageService, ICurrentUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _imageService = imageService;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            { 
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return LocalRedirect(returnUrl);
                }
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError(string.Empty, "This account has been locked due to unusual activity or behavior.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login or password. Please try again.");
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction(nameof(Login));
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = new User 
                { 
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.Email, 
                    Email = model.Email 
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return LocalRedirect(returnUrl);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                if (user == null)
                {
                    return RedirectToAction(nameof(Login));
                }

                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }

                    return View();
                }

                await _signInManager.RefreshSignInAsync(user);

                return LocalRedirect(returnUrl);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAccount()
        {
            var details = await Mediator.Send(new GetAccountDetailsQuery());

            ViewBag.HasAvatar = details.AvatarPath != null ? true : false; 

            var command = Mapper.Map<UpdateAccountCommand>(details);

            var countryListVm = await Mediator.Send(new GetCountryListQuery());

            ViewBag.Countries = countryListVm.Countries.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            return View(command);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAccount(UpdateAccountCommand command)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.HasAvatar = _userService.HasAvatar();

                var countryListVm = await Mediator.Send(new GetCountryListQuery());

                ViewBag.Countries = countryListVm.Countries.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList();

                return View(command);
            }

            await Mediator.Send(command);

            return RedirectToAction(nameof(UpdateAccount));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAvatar()
        {
            await Mediator.Send(new DeleteAvatarCommand());

            return RedirectToAction(nameof(UpdateAccount));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAccount()
        {
            await Mediator.Send(new DeleteAccountCommand());

            await _signInManager.SignOutAsync();

            return RedirectToAction(nameof(Login));
        }
    }
}
