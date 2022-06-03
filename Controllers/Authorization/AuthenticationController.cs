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

namespace EasyToEnter.ASP.Controllers.Authorization
{
    public class AuthenticationController : Controller
    {
        private readonly EasyToEnterDbContext _context;
        public AuthenticationController(EasyToEnterDbContext context)
        {
            _context = context;
        }



        private readonly int LifeSpan = 10;



        private async Task Authenticate(PersonModel person)
        {
            SessionModel session = new()
            {
                PersonId = person.Id,
                LifeSpan = (int)((DateTimeOffset)DateTime.Now.AddSeconds(LifeSpan)).ToUnixTimeSeconds()
            };

            await _context.AddAsync(session);
            await _context.SaveChangesAsync();

            ClaimsIdentity claimsIdentity = new(new[]
                {
                    new Claim("SessionId", session.Id.ToString()),
                    new Claim("Login", person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.RoleModel!.Name),
                    new Claim("PhoneNumber", person.PhoneNumber),
                    new Claim("LastName", person.LastName),
                    new Claim("FirstName", person.FirstName),
                    new Claim("EmailAddress", person.EmailAddress)
                }, CookieAuthenticationDefaults.AuthenticationScheme);

            ClaimsPrincipal claimsPrincipal = new(claimsIdentity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
        }



        [NotAuthorized]
        [HttpGet]
        public IActionResult Index() => RedirectToAction("Login");



        [NotAuthorized]
        [HttpGet]
        public IActionResult Login() => View();



        [NotAuthorized]
        [HttpGet]
        public IActionResult Register() => View();



        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }



        [AllowAnonymous]
        [SessionCheck]
        [HttpGet]
        public IActionResult AccessDenied() => View();



        [NotAuthorized]
        [HttpPost]
        public async Task<IActionResult> Login([FromForm(Name = "login")] string login, [FromForm(Name = "password")] string password)
        {
            if (login == null || password == null) return RedirectToAction("Login");

            PersonModel? person = await _context.Person.Include(p => p.RoleModel).SingleOrDefaultAsync(p => p.Login == login);

            if (person == null || Verify(password, person.PasswordHash) == false) return View();

            await Authenticate(person);

            return RedirectToAction("Index", "Home");
        }



        [NotAuthorized]
        [HttpPost]
        public async Task<IActionResult> Register([FromForm(Name = "login")] string login, [FromForm(Name = "password")] string password)
        {
            if (login == null || password == null) return RedirectToAction("Register");

            if (await _context.Person.SingleOrDefaultAsync(p => p.Login == login) != null) return View();

            PersonModel person = new()
            {
                FirstName = "Иван",
                LastName = "Иванов",
                MiddleName = "Иванович",
                Login = login,
                PasswordHash = HashPassword(password),
                EmailAddress = "isooterkin@gmail.com",
                PhoneNumber = "89121858950",
                RoleId = 2,
                RoleModel = new RoleModel() { Id = 2, Name = "User" }
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