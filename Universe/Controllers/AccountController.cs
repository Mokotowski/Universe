using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Universe.Models;

namespace Universe.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;

        public AccountsController(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login userLoginData)
        {
            if (!ModelState.IsValid)
            {
                return View(userLoginData);
            }

            await _signInManager.PasswordSignInAsync(userLoginData.LoginAccount, userLoginData.PasswordAccount, false, false);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register userRegisterData)
        {
            if (!ModelState.IsValid)
            {
                return View(userRegisterData);
            }

            var newUser = new UserModel
            {
                Email = userRegisterData.Email,
                UserName = userRegisterData.Login
            };

            await _userManager.CreateAsync(newUser, userRegisterData.Password);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
