using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCTest.Data;
using MVCTest.Models;
using MVCTest.ViewModels;

namespace MVCTest.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Login()
        {
            var response = new LoginVM();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
                return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.email);

            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.password);

                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Race");
                    }
                }

                TempData["Error"] = "Wrong credentials";
                return View(loginVM);
            }
            TempData["Error"] = "Wrong credentials";
            return View(loginVM);
        }

        public IActionResult Register()
        {
            var response = new RegisterVM();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }

            var user = await _userManager.FindByEmailAsync(registerVM.email);

            if (user != null)
            {
                TempData["Error"] = "User already exist";
                return View(registerVM);
            }

            AppUser appUser = new AppUser
            {
                Email = registerVM.email,
                UserName = registerVM.email
            };

            var newUser = await _userManager.CreateAsync(appUser, registerVM.password);

            if(newUser.Succeeded)
            {
                await _userManager.AddToRoleAsync(appUser, UserRoles.User);

            }
            return View("Index", "Race");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Race");
        }

    }
}
