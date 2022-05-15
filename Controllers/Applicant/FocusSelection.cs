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

            // Если указан фильтр областей, фильтруем
            if (area != null)
            {
                // Что выбрали
                AreaFocusModel? selectAreaFocus = areaFocusCollection.FirstOrDefault(a => a.AreaModel!.Id == area);

                if (selectAreaFocus == null) return NotFound();

                focusUniversityCollection = focusUniversityCollection
                    .Where(f => f.LevelFocusModel!.FocusModel!.AreaFocuss!.Select(af => af.AreaModel).Contains(selectAreaFocus.AreaModel));
            }

            // Все направленности
            List<LevelFocusModel> levelFocusList = focusUniversityCollection
                .Select(fu => fu.LevelFocusModel!)
                .Distinct()
                .ToList();

            // Конвертация областей в фильтры
            List<SelectListItem> areaFocusSelectList = areaFocusCollection
                .Select(af => af.AreaModel!)
                .Distinct()
                .Select(a => new SelectListItem($"{a.Name}", $"{a.Id}"))
                .ToList();

            // .Select(a => new SelectListItem($"{a.Name} ({focusUniversityCollection.Where(lf => lf.LevelFocusModel!.FocusModel!.AreaFocuss!.Contains(areaFocusCollection.Where(r => r.AreaModel!.Id == a.Id).First())).Count()})", a.Id.ToString()))

            // Если выбран какой либо фильтр, устанавливаем его
            if (area != null)
            {
                if (areaFocusSelectList.Any(l => l.Value == area.ToString()))
                    areaFocusSelectList.First(l => l.Value == area.ToString()).Selected = true;
            }

            return View(new FocusSelectionContainerViewModel(levelFocusList, focusUniversityCollection, areaFocusSelectList, level, direction));
        }
    }
}
