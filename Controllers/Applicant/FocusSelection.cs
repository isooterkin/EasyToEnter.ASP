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

            //List <LevelFocusModel> levelFocusList = await _context.LevelFocus
            //    .Where(l => l.LevelId == level)
            //    .Include(l => l.LevelModel)
            //    .Include(lf => lf.FocusModel)
            //        .ThenInclude(f => f!.DirectionModel)
            //    .Where(l => l.FocusModel!.DirectionId == direction)
            //    .Include(lf => lf.FocusModel)
            //        .ThenInclude(f => f!.DirectionModel)
            //            .ThenInclude(f => f!.GroupModel)
            //    .Include(lf => lf.FocusModel)
            //        .ThenInclude(lf => lf!.AreaFocuss)
            //            !.ThenInclude(lf => lf!.AreaModel)
            //    .ToListAsync();


            //IEnumerable<VariabilityModel> variabilityCollection = _context.Variability
            //    .Include(v => v.FormatModel)
            //    .Include(v => v.FormModel)
            //    .Include(v => v.PaymentModel)
            //    .Include(v => v.FocusUniversityModel)
            //        .ThenInclude(fu => fu!.LevelFocusModel)
            //            .ThenInclude(lf => lf!.LevelModel)
            //    .Where(v => v.FocusUniversityModel!.LevelFocusModel!.LevelId == level)
            //    .Include(v => v.FocusUniversityModel)
            //        .ThenInclude(fu => fu!.LevelFocusModel)
            //            .ThenInclude(lf => lf!.FocusModel)
            //                .ThenInclude(f => f!.DirectionModel)
            //                    .ThenInclude(d => d!.GroupModel)
            //    .Where(v => v.FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionId == direction);

            //IEnumerable<FocusUniversityModel> focusUniversityCollection = _context.FocusUniversity
            //    .Include(f => f.PaymentModel)
            //    .Include(f => f.FormModel)
            //    .Include(f => f.FormatModel)
            //    .Include(f => f.UniversityModel)
            //    .Include(f => f.LevelFocusModel)
            //        .ThenInclude(f => f!.LevelModel)
            //    .Where(f => f.LevelFocusModel!.LevelId == level)
            //    .Include(f => f.LevelFocusModel)
            //        .ThenInclude(f => f!.FocusModel)
            //            .ThenInclude(f => f!.DirectionModel)
            //                .ThenInclude(f => f!.GroupModel)
            //    .Where(f => f.LevelFocusModel!.FocusModel!.DirectionId == direction);

            // Все возможные области
            //IEnumerable<AreaFocusModel> areaFocusList = levelFocusList
            //    .SelectMany(f => f.FocusModel!.AreaFocuss!);

            IEnumerable<FocusUniversityModel> focusUniversityCollection = await _context.FocusUniversity
                .Include(fu => fu.LevelFocusModel)
                    .ThenInclude(lf => lf!.LevelModel)
                .Include(fu => fu.LevelFocusModel)
                    .ThenInclude(lf => lf!.FocusModel)
                        .ThenInclude(f => f!.DirectionModel)
                            .ThenInclude(d => d!.GroupModel)
                .Include(fu => fu.LevelFocusModel)
                    .ThenInclude(lf => lf!.FocusModel)
                        .ThenInclude(f => f!.AreaFocuss)
                            !.ThenInclude(f => f!.AreaModel)
                .Where(fu => fu!.LevelFocusModel!.LevelId == level)
                .Where(fu => fu!.LevelFocusModel!.FocusModel!.DirectionId == direction)
                .ToListAsync();

            // Все возможные области
            IEnumerable<AreaFocusModel> areaFocusCollection = focusUniversityCollection
                .SelectMany(f => f.LevelFocusModel!.FocusModel!.AreaFocuss!);

            // Конвертация областей в фильтры
            List<SelectListItem> areaFocusSelectList = areaFocusCollection
                .Select(af => af.AreaModel!)
                .Distinct()
                .Select(a => new SelectListItem(a.Name, a.Id.ToString()))
                .ToList();

            if (area != null)
            {
                var inContains = areaFocusCollection.Where(a => a.AreaModel!.Id == area).First();
                
                focusUniversityCollection = focusUniversityCollection
                    .Where(f => f.LevelFocusModel!.FocusModel!.AreaFocuss!.Contains(inContains));

                if (areaFocusSelectList.Any(l => l.Value == area.ToString()))
                    areaFocusSelectList.First(l => l.Value == area.ToString()).Selected = true;
            }

            List<LevelFocusModel> levelFocusList = focusUniversityCollection
                .Select(fu => fu.LevelFocusModel!)
                .Distinct()
                .ToList();

            return View(new FocusSelectionContainerViewModel(levelFocusList, focusUniversityCollection, areaFocusSelectList, level, direction));
        }
    }
}
