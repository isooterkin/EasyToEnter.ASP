using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.ViewsModels.Applicant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyToEnter.ASP.Controllers.Applicant
{
    public partial class ApplicantController
    {
        public IActionResult LevelSelection()
        {
            IEnumerable<FocusUniversityModel> focusUniversityCollection = _context.FocusUniversity
                .Include(fu => fu.LevelFocusModel)
                    .ThenInclude(lf => lf!.LevelModel);

            List<LevelModel> levelList = focusUniversityCollection
                .Select(fu => fu.LevelFocusModel!.LevelModel!)
                .Distinct()
                .ToList();

            return View(new LevelSelectionContainerViewModel(focusUniversityCollection, levelList));
        }
    }
}