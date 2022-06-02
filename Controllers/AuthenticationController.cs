using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace EasyToEnter.ASP.Controllers
{
    public class AuthenticationController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login() => User != null && User.Identity != null && User.Identity.IsAuthenticated == true ? RedirectToAction("Index", "Home") : View();



        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register() => User != null && User.Identity != null && User.Identity.IsAuthenticated == true ? RedirectToAction("Index", "Home") : View();



        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout() 
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }



        [AllowAnonymous]
        [HttpGet]
        public IActionResult AccessDenied() => View();



        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromForm(Name = "login")] string login, [FromForm(Name = "password")] string password)
        {
            if (login == null || password == null) return RedirectToAction("Login");

            ClaimsIdentity? claimsIdentity = null;

            if (login == "admin" && password == "12345")
                claimsIdentity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, "Admin")
                }, CookieAuthenticationDefaults.AuthenticationScheme);

            if (login == "applicant" && password == "12345")
                claimsIdentity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, "Applicant")
                }, CookieAuthenticationDefaults.AuthenticationScheme);

            if (claimsIdentity == null) return View();

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

            return RedirectToAction("Index", "Home");
        }


        public IActionResult Aaa()
        {
            var a = User.GetHashCode();

            return RedirectToAction("Index", "Home");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}