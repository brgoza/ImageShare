using ImageShare.Core.Models;
using ImageShare.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ImageShare.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(ILogger<AccountController> logger, SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager)
                => (_logger, _signInManager, _userManager) = (logger, signInManager, userManager);

        [HttpGet, AllowAnonymous]
        public IActionResult Login() { return View(); }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(obj.Email, obj.Password, obj.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("{User} logged in.", obj.Email);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View();
                }
            }

            return View();
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Register() { return View(); }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel obj)
        {
            if (!ModelState.IsValid) { return View(); }

            var user = new AppUser(obj.Email!);

            var result = await _userManager.CreateAsync(user, obj.Password);

            if (result.Succeeded)
            {
                _logger.LogInformation("User created new account with {email}", user.Email);
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
