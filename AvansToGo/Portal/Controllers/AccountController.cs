using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portal.Models;

namespace Portal.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _UserManager;
        private readonly SignInManager<IdentityUser> _SignInManager;

        public AccountController(
            UserManager<IdentityUser> UserManager,
            SignInManager<IdentityUser> SignInManager)
        {
            _UserManager = UserManager;
            _SignInManager = SignInManager;
            IdentitySeedData.EnsurePopulated(UserManager).Wait();
        }

        [AllowAnonymous]
        public IActionResult Login(string? returnUrl) => View(new LoginModel
        {
            ReturnUrl = returnUrl ?? "/"
        });

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel LoginModel)
        {
            if (ModelState.IsValid)
            {
                var User = await _UserManager.FindByEmailAsync(LoginModel.Email);

                if (User != null)
                {
                    await _SignInManager.SignOutAsync();

                    var SignInResult = await _SignInManager.PasswordSignInAsync(User, LoginModel.Password, false, false);
                    if (SignInResult.Succeeded)
                    {
                        return Redirect(LoginModel?.ReturnUrl ?? "/Home/Index");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid email or password");
            return View(LoginModel);
        }

        public async Task<IActionResult> LogOut()
        {
            await _SignInManager.SignOutAsync();
            return Redirect("/Home/Index");
        }

    }
}
