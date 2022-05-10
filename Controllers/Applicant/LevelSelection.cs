using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyToEnter.ASP.Controllers.Applicant
{
    public partial class ApplicantController
    {
        public IActionResult LevelSelection()
        {
            List<LevelModel?> levelList = new ();

            IEnumerable<LevelFocusModel?> levelFocusCollection = _context.LevelFocus
                .Include(l => l.LevelModel)
                .Include(lf => lf.FocusModel)
                .ThenInclude(f => f!.DirectionModel)
                .ThenInclude(d => d!.GroupModel)
                .ThenInclude(s => s!.ScienceModel);

            if (levelFocusCollection.Any() == false) return View(levelList);

            levelList = levelFocusCollection.Select(g => g!.LevelModel).Distinct().ToList();

            return View(levelList);
        }
    }
}