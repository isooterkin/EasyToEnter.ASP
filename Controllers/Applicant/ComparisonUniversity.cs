using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.Tools.Authorization;
using EasyToEnter.ASP.Tools.Authorization.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyToEnter.ASP.Controllers.Applicant
{
    public partial class ApplicantController
    {
        [Authorized]
        public async Task<IActionResult> ComparisonUniversityAsync()
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

            return View(personModel.UniversityFavoritess);
        }
    }
}