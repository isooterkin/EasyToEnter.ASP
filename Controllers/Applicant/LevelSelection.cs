using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.ViewsModels.Applicant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyToEnter.ASP.Controllers.Applicant
{
    public partial class ApplicantController
    {
        public async Task<IActionResult> LevelSelection()
        {
            // Все "Вариативность"
            List<VariabilityModel> variabilityList = await _context.Variability
                .Include(v => v.FocusUniversityModel!.LevelFocusModel!.LevelModel)
                .ToListAsync();

            List<LevelModel> levelList = variabilityList
                .Select(v => v.FocusUniversityModel!.LevelFocusModel!.LevelModel!)
                .Distinct()
                .ToList();

            return View(new LevelSelectionContainerViewModel(variabilityList, levelList));
        }
    }
}