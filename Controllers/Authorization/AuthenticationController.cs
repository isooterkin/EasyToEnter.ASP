using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Models;
using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.ViewsModels.Authentication;
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
        public AuthenticationController(EasyToEnterDbContext context) => _context = context;



        private readonly int LifeSpan = 200;



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
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.RoleModel!.Name),
                    new Claim("Login", person.Login)
                }, CookieAuthenticationDefaults.AuthenticationScheme);

            ClaimsPrincipal claimsPrincipal = new(claimsIdentity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
        }



        [NotAuthorized]
        [HttpGet]
        public IActionResult Index() => RedirectToAction("Login");



        [NotAuthorized]
        [HttpGet]
        public IActionResult Login() => View(new SingInViewModel());



        [NotAuthorized]
        [HttpGet]
        public IActionResult Register() => View(new SingUpViewModel());



        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            string? sessionIdString = User.FindFirst(x => x.Type == "SessionId")?.Value;

            if (sessionIdString != null)
            {
                Guid sessionId = new(sessionIdString);

                SessionModel? session = await _context.Session.SingleOrDefaultAsync(s => s.Id == sessionId);

                if (session != null)
                {
                    _context.Remove(session);
                    await _context.SaveChangesAsync();
                }
            }

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }



        [AllowAnonymous]
        [SessionCheck]
        [HttpGet]
        public IActionResult AccessDenied() => View();



        [NotAuthorized]
        [HttpPost]
        public async Task<IActionResult> Login([Bind("Login,Password")] SingInViewModel personLogin)
        {
            if (ModelState.IsValid)
            {
                PersonModel? person = await _context.Person.Include(p => p.RoleModel).SingleOrDefaultAsync(p => p.Login == personLogin.Login);

                if (person == null)
                {
                    ModelState.AddModelError(nameof(personLogin.Login), "Пользователь не найден.");
                    return View(personLogin);
                }
                else 
                { 
                    if (Verify(personLogin.Password, person.PasswordHash) == false)
                    {
                        ModelState.AddModelError(nameof(personLogin.Password), "Неверный пароль.");
                        return View(personLogin);
                    }

                    await Authenticate(person);

                    return RedirectToAction("Index", "Home");
                }
            }
            else return View(personLogin);
        }



        [NotAuthorized]
        [HttpPost]
        public async Task<IActionResult> Register([Bind("Login,Password,PasswordRepeat,EmailAddress")] SingUpViewModel personRegister)
        {
            if (ModelState.IsValid)
            {
                if (personRegister.PasswordRepeat != personRegister.Password)
                {
                    ModelState.AddModelError(nameof(personRegister.Password), "Пароли не совпадают.");
                    ModelState.AddModelError(nameof(personRegister.PasswordRepeat), "Пароли не совпадают.");
                    return View(personRegister);
                }

                if (await _context.Person.SingleOrDefaultAsync(p => p.Login == personRegister.Login) != null)
                {
                    ModelState.AddModelError(nameof(personRegister.Login), "Пользователь уже существует.");
                    return View(personRegister); 
                }

                PersonModel person = new()
                {
                    Login = personRegister.Login,
                    PasswordHash = HashPassword(personRegister.Password),
                    EmailAddress = personRegister.EmailAddress,
                    RoleId = 2
                };

                await _context.AddAsync(person);
                await _context.SaveChangesAsync();

                person.RoleModel = new RoleModel() { Id = 2, Name = "Абитуриент" };

                await Authenticate(person);

                return RedirectToAction("Index", "Home");
            }
            else return View(personRegister);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}