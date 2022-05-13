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
                .Where(l => l.FocusModel!.DirectionId == direction);

            IEnumerable<FocusUniversityModel> focusUniversityCollection = _context.FocusUniversity
                .Include(f => f.PaymentModel)
                .Include(f => f.FormModel)
                .Include(f => f.FormatModel)
                .Include(f => f.UniversityModel)
                .Include(f => f.LevelFocusModel)
                .ThenInclude(f => f!.LevelModel)
                .Where(f => f.LevelFocusModel!.LevelId == level)
                .Include(f => f.LevelFocusModel)
                .ThenInclude(f => f!.FocusModel)
                .ThenInclude(f => f!.DirectionModel)
                .ThenInclude(f => f!.GroupModel)
                .Where(f => f.LevelFocusModel!.FocusModel!.DirectionId == direction);

            return View(new FocusSelectionContainerViewModel(levelFocusCollection, focusUniversityCollection, level));
        }
    }
}
