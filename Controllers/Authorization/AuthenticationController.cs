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
    public class AuthenticationController : MyController
    {
        public AuthenticationController(EasyToEnterDbContext context) : base(context) { }



        private readonly int LifeSpan = 31556926;



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



        [AllowAnonymous]
        [SessionCheck]
        [HttpGet]
        public async Task<IActionResult> Index() => await CheckSession() ? RedirectToAction("Index", "Home") : RedirectToAction("Login");



        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Login() => await CheckSession() ? RedirectToAction("Index", "Home") : View();



        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Register() => await CheckSession() ? RedirectToAction("Index", "Home") : View();



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
            if (await CheckSession()) return RedirectToAction("Index", "Home");

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
            if (await CheckSession()) return RedirectToAction("Index", "Home");

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