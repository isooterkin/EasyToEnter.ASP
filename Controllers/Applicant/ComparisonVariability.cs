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
        public async Task<IActionResult> ComparisonVariabilityAsync()
        {
            // Избранные вариативности
            List<VariabilityFavoritesModel> variabilityFavoritesList = await _context.VariabilityFavorites
                .Include(vf => vf.VariabilityModel!.FocusUniversityModel!.UniversityModel)
                .Include(vf => vf.VariabilityModel!.FocusUniversityModel!.LevelFocusModel!.FocusModel)
                .Include(vf => vf.VariabilityModel!.FocusUniversityModel!.DisciplineFocusUniversitys!)
                        .ThenInclude(v => v!.DisciplineModel)
                .Include(vf => vf.VariabilityModel!.HistoryVariabilitys)
                .Include(vf => vf.VariabilityModel!.FormModel)
                .Include(vf => vf.VariabilityModel!.FormatModel)
                .Include(vf => vf.VariabilityModel!.PaymentModel)
                .Include(vf => vf.PersonModel)
                .Where(p => p.PersonId == User.Id())
                .ToListAsync();

            return View(variabilityFavoritesList);
        }
    }
}