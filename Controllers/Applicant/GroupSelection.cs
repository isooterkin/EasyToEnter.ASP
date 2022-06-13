using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.ViewsModels.Applicant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyToEnter.ASP.Controllers.Applicant
{
    public partial class ApplicantController
    {
        public async Task<IActionResult> GroupSelection([FromQuery(Name = "level")] int level, [FromQuery(Name = "science")] int science)
        {
            if (level <= 0 || science <= 0) return NotFound();

            // Все "Вариативность"
            List<VariabilityModel> variabilityList = await _context.Variability
                .Include(v => v.FocusUniversityModel!.LevelFocusModel!.LevelModel)
                .Where(v => v.FocusUniversityModel!.LevelFocusModel!.LevelId == level)
                .Include(v => v.FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionModel!.GroupModel!.ScienceModel)
                .Where(v => v.FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionModel!.GroupModel!.ScienceId == science)
                .ToListAsync();

            List<GroupModel> groupList = variabilityList
                .Select(v => v.FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionModel!.GroupModel!)
                .Distinct()
                .ToList();

            return View(new GroupSelectionContainerViewModel(variabilityList, groupList, level));
        }
    }
}