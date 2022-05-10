using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.ViewsModels.Applicant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyToEnter.ASP.Controllers.Applicant
{
    public partial class ApplicantController
    {
        public IActionResult FocusSelection(int level, int direction)
        {
            IEnumerable<LevelFocusModel> levelFocusCollection = _context.LevelFocus
                .Where(l => l.LevelId == level)
                .Include(l => l.LevelModel)
                .Include(lf => lf.FocusModel)
                .ThenInclude(f => f!.DirectionModel)
                .Where(l => l.FocusModel!.DirectionModel!.Id == direction);

            return View(new FocusSelectionContainerViewModel(levelFocusCollection, level));
        }
    }
}
