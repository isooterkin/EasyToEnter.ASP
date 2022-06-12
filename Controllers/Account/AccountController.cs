using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EasyToEnter.ASP.Tools.Authorization;
using EasyToEnter.ASP.Tools.Authorization.Attributes;
using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.ViewsModels.Account;

namespace EasyToEnter.ASP.Controllers.Account
{
    public class AccountController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public AccountController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        [Authorized]
        public async Task<IActionResult> Index()
        {
            // Пользователь
            PersonModel personModel = await _context.Person
                .Include(p => p.VariabilityFavoritess)
                    !.ThenInclude(vf => vf.VariabilityModel)
                        !.ThenInclude(v => v!.FocusUniversityModel)
                            !.ThenInclude(fu => fu!.UniversityModel)
                .Include(p => p.VariabilityFavoritess)
                    !.ThenInclude(vf => vf.VariabilityModel)
                        !.ThenInclude(v => v!.FocusUniversityModel)
                            !.ThenInclude(fu => fu!.LevelFocusModel)
                                !.ThenInclude(lf => lf!.FocusModel)
                .Include(p => p.UniversityFavoritess)
                    !.ThenInclude(uf => uf!.UniversityModel)
                .SingleAsync(p => p.Id == User.Id());

            return View(new AccountViewModel(personModel.VariabilityFavoritess!, personModel.UniversityFavoritess!));
        }
    }
}