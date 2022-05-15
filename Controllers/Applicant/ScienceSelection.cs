using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.ViewsModels.Applicant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyToEnter.ASP.Controllers.Applicant
{
    public partial class ApplicantController
    {
        public IActionResult ScienceSelection(int level)
        {
            IEnumerable<FocusUniversityModel> focusUniversityCollection = _context.FocusUniversity
                .Include(fu => fu.LevelFocusModel)
                    .ThenInclude(lf => lf!.LevelModel)
                .Include(fu => fu.LevelFocusModel)
                    .ThenInclude(lf => lf!.FocusModel)
                        .ThenInclude(f => f!.DirectionModel)
                            .ThenInclude(d => d!.GroupModel)
                                .ThenInclude(g => g!.ScienceModel)
                .Where(fu => fu.LevelFocusModel!.LevelId == level);

            List<ScienceModel> scienceList = focusUniversityCollection
                .Select(fu => fu.LevelFocusModel!.FocusModel!.DirectionModel!.GroupModel!.ScienceModel!)
                .Distinct()
                .ToList();

            return View(new ScienceSelectionContainerViewModel(focusUniversityCollection, scienceList, level));
        }
    }
}