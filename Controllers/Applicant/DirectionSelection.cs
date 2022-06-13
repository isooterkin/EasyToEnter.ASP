using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.ViewsModels.Applicant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyToEnter.ASP.Controllers.Applicant
{
    public partial class ApplicantController
    {
        public async Task<IActionResult> DirectionSelection([FromQuery(Name = "level")] int level, [FromQuery(Name = "group")] int group)
        {
            if (level <= 0 || group <= 0) return NotFound();

            // Все "Вариативность"
            List<VariabilityModel> variabilityList = await _context.Variability
                .Include(v => v.FocusUniversityModel!.LevelFocusModel!.LevelModel)
                .Where(v => v.FocusUniversityModel!.LevelFocusModel!.LevelId == level)
                .Include(v => v.FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionModel!.GroupModel!.ScienceModel)
                .Where(v => v.FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionModel!.GroupId == group)
                .ToListAsync();

            // Все "Направление"
            List<DirectionModel> directionList = variabilityList
                .Select(v => v.FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionModel!)
                .Distinct()
                .ToList();

            return View(new DirectionSelectionContainerViewModel(variabilityList, directionList, level));
        }
    }
}