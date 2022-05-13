using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.ViewsModels.Applicant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EasyToEnter.ASP.Controllers.Applicant
{
    public partial class ApplicantController
    {
        public async Task<IActionResult> FocusSelection(int level, int direction)
        {
            List<LevelFocusModel> levelFocusList = await _context.LevelFocus
                .Where(l => l.LevelId == level)
                .Include(l => l.LevelModel)
                .Include(lf => lf.FocusModel)
                .ThenInclude(f => f!.DirectionModel)
                .ThenInclude(f => f!.GroupModel)
                .Where(l => l.FocusModel!.DirectionId == direction)
                .ToListAsync();

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

            int[] levelFocusIdArray = levelFocusList.Select(f => f.FocusId).Distinct().ToArray();

            List<SelectListItem> areaFocusList = await _context.AreaFocus
                .Where(l => levelFocusIdArray.Contains(l.FocusId))
                .Include(l => l.AreaModel)
                .Select(l => new SelectListItem(l.AreaModel!.Name, l.Id.ToString()))
                .ToListAsync();

            return View(new FocusSelectionContainerViewModel(levelFocusList, focusUniversityCollection, areaFocusList));
        }
    }
}
