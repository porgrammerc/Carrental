using CarRental.Models;
using CarRental.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager,
            RoleManager<IdentityRole<Guid>> roleManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            var existingUser = await _userManager.FindByEmailAsync(register.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "Użytkownik o takim adresie e-mail już istnieje");
                return View(register);
            }

            var user = new User
            {
                Name = register.Name,
                LastName = register.LastName,
                Email = register.Email,
                UserName = register.Email
            };

            var registeredUser = await _userManager.CreateAsync(user, register.Password);
            if (registeredUser.Succeeded)
            {
                var usersCount = _userManager.Users.Count();

                if (usersCount == 1)
                {
                    await _roleManager.CreateAsync(new IdentityRole<Guid>(Role.User.ToString()));
                    await _roleManager.CreateAsync(new IdentityRole<Guid>(Role.Admin.ToString()));
                    await _userManager.AddToRoleAsync(user, Role.Admin.ToString());
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, Role.User.ToString());
                }
            }
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {
            var existingUser = await _userManager.FindByEmailAsync(login.Email);
            if (existingUser != null)
            {
                if (await _userManager.CheckPasswordAsync(existingUser, login.Password))
                {
                    var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, true, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }            

            ModelState.AddModelError("Password", "Niepoprawne dane logowania");
            return View(login);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = $"{nameof(Role.Admin)}")]
        public IActionResult GetUsers()
        {
            return View(_userManager.Users.ToList());
        }
    }
}