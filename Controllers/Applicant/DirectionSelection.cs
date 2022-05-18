using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.ViewsModels.Applicant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyToEnter.ASP.Controllers.Applicant
{
    public partial class ApplicantController
    {
        public IActionResult DirectionSelection([FromQuery(Name = "level")] int level, [FromQuery(Name = "group")] int group)
        {
            if (level <= 0 || group <= 0) return NotFound();

            // Все "Вариативность"
            List<VariabilityModel> variabilityList = _context.Variability
                .Include(v => v.FocusUniversityModel)
                    .ThenInclude(fu => fu!.LevelFocusModel)
                        .ThenInclude(lf => lf!.LevelModel)
                .Include(v => v.FocusUniversityModel)
                    .ThenInclude(fu => fu!.LevelFocusModel)
                        .ThenInclude(lf => lf!.FocusModel)
                            .ThenInclude(f => f!.DirectionModel)
                                .ThenInclude(d => d!.GroupModel)
                .Where(v => v.FocusUniversityModel!.LevelFocusModel!.LevelId == level)
                .Where(v => v.FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionModel!.GroupId == group)
                .ToList();

            // Все "Направление"
            List<DirectionModel> directionList = variabilityList
                .Select(v => v.FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionModel!)
                .Distinct()
                .ToList();

            return View(new DirectionSelectionContainerViewModel(variabilityList, directionList, level));
        }
    }
}