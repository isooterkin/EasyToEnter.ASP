using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.ViewsModels.Applicant;
using EasyToEnter.ASP.ViewsModels.Components;
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
            [FromQuery(Name = "area")] int? area,
            [FromQuery(Name = "profession")] int? profession)
        {
            if (level <= 0 || direction <= 0 || (area != null && area <= 0) || (profession != null && profession <= 0)) return NotFound();

            // Все "Вариативность"
            List<VariabilityModel> variabilityList = await _context.Variability
                .Include(v => v.FocusUniversityModel)
                    .ThenInclude(fu => fu!.LevelFocusModel)
                        .ThenInclude(lf => lf!.LevelModel)
                .Include(v => v.FocusUniversityModel)
                    .ThenInclude(fu => fu!.LevelFocusModel)
                        .ThenInclude(lf => lf!.FocusModel)
                            .ThenInclude(f => f!.DirectionModel)
                                .ThenInclude(d => d!.GroupModel)
                                    .ThenInclude(g => g!.ScienceModel)
                .Include(v => v.FocusUniversityModel)
                    .ThenInclude(fu => fu!.LevelFocusModel)
                        .ThenInclude(lf => lf!.FocusModel)
                            .ThenInclude(f => f!.AreaFocuss)
                                !.ThenInclude(af => af!.AreaModel)
                .Include(v => v.FocusUniversityModel)
                    .ThenInclude(fu => fu!.LevelFocusModel)
                        .ThenInclude(lf => lf!.FocusModel)
                            .ThenInclude(f => f!.ProfessionFocuss)
                                !.ThenInclude(pf => pf!.ProfessionModel)
                                    !.ThenInclude(p => p!.TypeProfessionModel)
                .Where(v => v.FocusUniversityModel!.LevelFocusModel!.LevelId == level)
                .Where(v => v.FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionId == direction)
                .ToListAsync();

            // Все "Область"
            List<AreaModel> areaList = variabilityList
                .SelectMany(v => v.FocusUniversityModel!.LevelFocusModel!.FocusModel!.AreaFocuss!)
                .Select(af => af.AreaModel!)
                .Distinct()
                .ToList();

            // Все "Профессия"
            List<ProfessionModel> professionList = variabilityList
                .SelectMany(v => v.FocusUniversityModel!.LevelFocusModel!.FocusModel!.ProfessionFocuss!)
                .Select(pf => pf.ProfessionModel!)
                .Distinct()
                .ToList();

            // Все "Уровень - Направленность"
            List<LevelFocusModel> levelFocusList = variabilityList
                .Select(v => v.FocusUniversityModel!.LevelFocusModel!)
                .Distinct()
                .ToList();

            // "Область" -> Фильтр
            List<SelectListItemSubtext> areaSelectListItem = areaList
                .Select(a => new SelectListItemSubtext
                {
                    Text = a.Name.ToString(),
                    Value = a.Id.ToString(),
                    Selected = a.Id == area,
                    Subtext = levelFocusList.Where(f => f.FocusModel!.AreaFocuss!.Select(af => af.AreaModel).Contains(a)).Count().ToString(),
                }).ToList();

            // "Профессия" -> Фильтр
            List<SelectListItemSubtext> professionSelectListItem = professionList
                .Select(p => new SelectListItemSubtext
                {
                    Text = p.Name.ToString(),
                    Value = p.Id.ToString(),
                    Selected = p.Id == profession,
                    Subtext = levelFocusList.Where(f => f.FocusModel!.ProfessionFocuss!.Select(pf => pf.ProfessionModel).Contains(p)).Count().ToString(),
                }).ToList();

            // Фильтрация по "Область"
            if (area != null)
            {
                // Выбранная "Область"
                AreaModel? selectArea = areaList.FirstOrDefault(a => a.Id == area);

                // Если "Область" не существует
                if (selectArea == null) return NotFound();

                // Фильтруем "Вариативность"
                variabilityList = variabilityList
                    .Where(v => v.FocusUniversityModel!.LevelFocusModel!.FocusModel!.AreaFocuss!.Select(af => af.AreaModel).Contains(selectArea))
                    .ToList();

                // Все "Уровень - Направленность"
                levelFocusList = variabilityList
                    .Select(v => v.FocusUniversityModel!.LevelFocusModel!)
                    .Distinct()
                    .ToList();
            }

            // Фильтрация по "Профессия"
            if (profession != null)
            {
                // Выбранная "Профессия"
                ProfessionModel? professionArea = professionList.FirstOrDefault(p => p.Id == profession);

                // Если "Профессия" не существует
                if (professionArea == null) return NotFound();

                // Фильтруем "Вариативность"
                variabilityList = variabilityList
                    .Where(v => v.FocusUniversityModel!.LevelFocusModel!.FocusModel!.ProfessionFocuss!.Select(pf => pf.ProfessionModel).Contains(professionArea))
                    .ToList();

                // Все "Уровень - Направленность"
                levelFocusList = variabilityList
                    .Select(v => v.FocusUniversityModel!.LevelFocusModel!)
                    .Distinct()
                    .ToList();
            }

            return View(new FocusSelectionContainerViewModel(variabilityList, levelFocusList, areaSelectListItem, professionSelectListItem, level, direction));
        }
    }
}