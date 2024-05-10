using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcMentor.Models;
using MvcMentor.ViewModels;

namespace MvcMentor.Controllers
{
	public class AccountController:Controller
	{
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(MemberRegisterViewModel member)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser appUser = new AppUser()
            {
                FullName=member.FullName,
                Email=member.Email,
                UserName=member.UserName,
            };
            var result = await _userManager.CreateAsync(appUser, member.Password);

            if (!result.Succeeded)
            {
                foreach (var err in result.Errors)
                {
                    if (err.Code == "DuplicateUserName")
                        ModelState.AddModelError("UserName", "UserName is already taken");
                    else ModelState.AddModelError("", err.Description);
                }
                return View();
            }

            return RedirectToAction("login", "account");

        }
        [HttpPost]
        public async Task<IActionResult> Login(MemberLoginViewModal member)
        {
            if (!ModelState.IsValid) return View();

            AppUser? user = await _userManager.FindByEmailAsync(member.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Email or Pasword incorrect!");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(user, member.Password, false, false);

          
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Email or Pasword incorrect!");
                return View();
            }
            return RedirectToAction("index", "home");

        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
    }
}

