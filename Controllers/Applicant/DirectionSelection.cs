using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.ViewsModels.Applicant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyToEnter.ASP.Controllers.Applicant
{
    public partial class ApplicantController
    {
        public IActionResult DirectionSelection(int level, int group)
        {
            IEnumerable<FocusUniversityModel> focusUniversityCollection = _context.FocusUniversity
                .Include(fu => fu.LevelFocusModel)
                    .ThenInclude(lf => lf!.LevelModel)
                .Include(fu => fu.LevelFocusModel)
                    .ThenInclude(lf => lf!.FocusModel)
                        .ThenInclude(f => f!.DirectionModel)
                            .ThenInclude(d => d!.GroupModel)
                .Where(fu => fu.LevelFocusModel!.LevelId == level)
                .Where(fu => fu.LevelFocusModel!.FocusModel!.DirectionModel!.GroupId == group);

            List<DirectionModel> directionList = focusUniversityCollection
                .Select(fu => fu.LevelFocusModel!.FocusModel!.DirectionModel!)
                .Distinct()
                .ToList();

            return View(new DirectionSelectionContainerViewModel(focusUniversityCollection, directionList, level));
        }
    }
}