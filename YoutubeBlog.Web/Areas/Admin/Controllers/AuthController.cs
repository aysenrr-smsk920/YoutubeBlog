using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YoutubeBlog.Entity.DTOs.Users;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UsersLoginDTO usersLoginDTO)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(usersLoginDTO.Email);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, usersLoginDTO.Password, usersLoginDTO.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home", new { Area = "Admin" });
                    }
                    else
                    {
                        ModelState.AddModelError("", "E-posta adresiniz ya da şifreniz yanlıştır!");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "E-posta adresiniz ya da şifreniz yanlıştır!");
                    return View();
                }
            }
            else
            {
                return View();
            }

        }
        [AllowAnonymous]
        [HttpGet]
        public  async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { Area = "" });
        }
        [AllowAnonymous]
        [HttpGet]
        public  async Task<IActionResult> AccessDenied()
        {;
            return View();
        }

    }
}
