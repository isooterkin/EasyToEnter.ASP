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
            SessionModel session = new() { PersonId = person.Id };

            await _context.AddAsync(session);
            await _context.SaveChangesAsync();

            ClaimsIdentity claimsIdentity = new(new[]
                {
                    new Claim("SessionId", session.Id.ToString()),
                    new Claim("Login", person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.RoleId.ToString()),
                    new Claim("PhoneNumber", person.PhoneNumber),
                    new Claim("LastName", person.LastName),
                    new Claim("FirstName", person.FirstName),
                    new Claim("EmailAddress", person.EmailAddress)
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
        [HttpPost]
        public async Task<IActionResult> Logout() 
        {
            await LogoutSession();
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

            if (person == null || Verify(password, person.PasswordHash) == false) return View();

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
                MiddleName = "Иванович",
                Login = login,
                PasswordHash = HashPassword(password),
                EmailAddress = "isooterkin@gmail.com",
                PhoneNumber = "89121858950",
                RoleId = 2
            };

            await _context.AddAsync(person);
            await _context.SaveChangesAsync();

            await Authenticate(person);

            return RedirectToAction("Index", "Home");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}