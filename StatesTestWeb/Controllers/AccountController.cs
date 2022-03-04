using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StatesTest.Data.Repositories;
using StatesTestWeb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StatesTestWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/Home/Index");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginInputDto userToLogin)
        {
            var user =  _userRepository.GetAll().FirstOrDefault(u => u.UserName == userToLogin.UserName && u.Password == userToLogin.Password);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userToLogin.UserName),
                    new Claim("FullName", userToLogin.UserName),
                    new Claim("UserId", user.UserId.ToString()),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    RedirectUri = "/Home/Index",
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return Redirect(authProperties.RedirectUri);
            }

            TempData["ErrorLoginMessage"] = "Username or Password incorrect";

            return Redirect("/Account/Login");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("/Account/Login");
        }

    }
}
