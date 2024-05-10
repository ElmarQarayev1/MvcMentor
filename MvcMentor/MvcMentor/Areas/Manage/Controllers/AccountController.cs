using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcMentor.Areas.Manage.ViewModels;
using MvcMentor.Data;
using MvcMentor.Models;

namespace MvcMentor.Areas.Manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userManager = userManager;

        }
        public async Task<IActionResult> CreateAdmin()
        {
            AppUser appUser = new AppUser()
            {
                UserName = "admin"
            };
            var result = await _userManager.CreateAsync(appUser, "Admin123");

            return Json(result);
        }
        public async Task<IActionResult> CreateRoles()
        {
            await _roleManager.CreateAsync(new IdentityRole("admin"));
            await _roleManager.CreateAsync(new IdentityRole("member"));
            return Ok();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginViewModel admin)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser? appUser = await _userManager.FindByNameAsync(admin.UserName);

            if (appUser == null)
            {
                ModelState.AddModelError("", "UserName or Password is not true");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(appUser, admin.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "UserName or Password is not true");
                return View();
            }

            return RedirectToAction("index", "dashboard");
        }

    }
}