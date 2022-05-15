using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.ViewsModels.Applicant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EasyToEnter.ASP.Controllers.Applicant
{
    public partial class ApplicantController
    {
        public async Task<IActionResult> FocusSelection(
            [FromQuery(Name = "level")] int level,
            [FromQuery(Name = "direction")] int direction,
            [FromQuery(Name = "area")] int? area)
        {
            if ((level <= 0 || direction <= 0) || (area != null && area <= 0)) return NotFound();

            List <LevelFocusModel> levelFocusList = await _context.LevelFocus
                .Where(l => l.LevelId == level)
                .Include(l => l.LevelModel)
                .Include(lf => lf.FocusModel)
                    .ThenInclude(f => f!.DirectionModel)
                .Where(l => l.FocusModel!.DirectionId == direction)
                .Include(lf => lf.FocusModel)
                    .ThenInclude(f => f!.DirectionModel)
                        .ThenInclude(f => f!.GroupModel)
                .Include(lf => lf.FocusModel)
                    .ThenInclude(lf => lf!.AreaFocuss)
                        !.ThenInclude(lf => lf!.AreaModel)
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

            // Все возможные области
            IEnumerable<AreaFocusModel> areaFocusList = levelFocusList
                .SelectMany(f => f.FocusModel!.AreaFocuss!);

            // Области в фильтрах
            List<SelectListItem> areaFocusSelectList = areaFocusList
                .Select(l => new SelectListItem(l.AreaModel!.Name, l.Id.ToString()))
                .ToList();

            if (area != null)
            {
                var inContains = areaFocusList.Where(a => a.Id == area).First();

                levelFocusList = levelFocusList
                    .Where(f => f.FocusModel!.AreaFocuss!.Contains(inContains))
                    .ToList();
                
                if (areaFocusSelectList.Any(l => l.Value == area.ToString()))
                    areaFocusSelectList.First(l => l.Value == area.ToString()).Selected = true;
            }

            return View(new FocusSelectionContainerViewModel(levelFocusList, focusUniversityCollection, areaFocusSelectList, level, direction));
        }
    }
}
