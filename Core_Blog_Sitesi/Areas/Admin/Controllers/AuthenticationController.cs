using EntityLayer.Dtos.Users;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Core_Blog_Sitesi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthenticationController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AuthenticationController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            if(ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(userLoginDto.Email);
                if(user!=null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, userLoginDto.Password,userLoginDto.RememberMe,false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home", new { Area = "Admin" });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Eposta veya şifreniz yanlış.");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Eposta veya şifreniz yanlış.");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { Area = "" });
        }

        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }
       
    }
}
