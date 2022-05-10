using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyToEnter.ASP.Controllers.Applicant
{
    public partial class ApplicantController
    {
        public IActionResult LevelSelection()
        {
            IEnumerable<LevelFocusModel> levelFocusCollection = _context.LevelFocus
                .Include(l => l.LevelModel)
                .Include(lf => lf.FocusModel);

            List<LevelModel?> levelList = levelFocusCollection
                .Select(g => g!.LevelModel)
                .Distinct()
                .ToList();

            return View(levelList);
        }
    }
}