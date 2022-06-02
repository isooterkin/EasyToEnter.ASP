using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Models;
using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using static BCrypt.Net.BCrypt;


namespace EasyToEnter.ASP.Controllers
{
    public class AuthenticationController : MyController
    {
        public AuthenticationController(EasyToEnterDbContext context): base(context) {}



        private async Task Authenticate(PersonModel person)
        {
            ClaimsIdentity claimsIdentity = new(new[]
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.RoleId.ToString()),
                    new Claim(ClaimTypes.MobilePhone, person.PhoneNumber),
                    new Claim(ClaimTypes.Name, person.FirstName),
                    new Claim(ClaimTypes.Email, person.EmailAddress)
                }, CookieAuthenticationDefaults.AuthenticationScheme);

            ClaimsPrincipal claimsPrincipal = new(claimsIdentity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
        }



        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login() => CheckIdentity() ? RedirectToAction("Index", "Home") : View();



        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register() => CheckIdentity() ? RedirectToAction("Index", "Home") : View();



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
            if (CheckIdentity()) return RedirectToAction("Index", "Home");

            if (login == null || password == null) return RedirectToAction("Login");

            PersonModel? person = await _context.Person.Include(p => p.RoleModel).SingleOrDefaultAsync(p => p.Login == login);

            if (person == null || Verify(password, person.PasswordHash)) return View();

            await Authenticate(person);

            return RedirectToAction("Index", "Home");
        }



        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromForm(Name = "login")] string login, [FromForm(Name = "password")] string password)
        {
            if (CheckIdentity()) return RedirectToAction("Index", "Home");

            if (login == null || password == null) return RedirectToAction("Register");

            if (await _context.Person.SingleOrDefaultAsync(p => p.Login == login) != null) return View();

            PersonModel person = new () 
            { 
                FirstName = "Иван",
                LastName = "Иванов",
                MiddleName = "",
                Login = login,
                PasswordHash = HashPassword(password),
                EmailAddress = "",
                PhoneNumber = "89121858950",
                RoleId = 1
            };

            await Authenticate(person);

            await _context.AddAsync(person);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}