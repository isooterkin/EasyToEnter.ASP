using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Models;
using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.Tools.Authorization;
using EasyToEnter.ASP.Tools.Authorization.Attributes;
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



        private readonly int LifeSpan = 999999;



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
                    new Claim("Role", person.RoleModel!.Name),
                    new Claim("Login", person.Login),
                    new Claim("Id", person.Id.ToString())
                }, CookieAuthenticationDefaults.AuthenticationScheme);

            ClaimsPrincipal claimsPrincipal = new(claimsIdentity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
        }



        [HttpGet]
        [NotAuthorized]
        public IActionResult Index() => RedirectToAction("Login");



        [HttpGet]
        [NotAuthorized]
        public IActionResult Login() => View(new SingInViewModel());



        [HttpGet]
        [NotAuthorized]
        public IActionResult Register() => View(new SingUpViewModel());



        [HttpGet]
        [Authorized]
        public async Task<IActionResult> Logout()
        {
            try
            {
                Guid? sessionId = User.SessionId();

                if (sessionId != null)
                {
                    SessionModel? session = _context.Session
                        .SingleOrDefault(s => s.Id == sessionId);

                    if (session != null)
                    {
                        _context.Session.Remove(session);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch { }

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }



        [AllowAnonymous]
        [SessionCheck]
        [HttpGet]
        public IActionResult AccessDenied() => View();



        [HttpPost]
        [NotAuthorized]
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



        [HttpPost]
        [NotAuthorized]
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