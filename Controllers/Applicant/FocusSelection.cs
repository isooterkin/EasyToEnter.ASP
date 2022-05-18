﻿using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.ViewsModels.Applicant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EasyToEnter.ASP.Controllers.Applicant
{
    public partial class ApplicantController
    {
        public IActionResult FocusSelection(
            [FromQuery(Name = "level")] int level,
            [FromQuery(Name = "direction")] int direction,
            [FromQuery(Name = "area")] int? area)
        {
            if ((level <= 0 || direction <= 0) || (area != null && area <= 0)) return NotFound();

            // Все "Вариативность"
            List<VariabilityModel> variabilityList = _context.Variability
                .Include(v => v.FocusUniversityModel)
                    .ThenInclude(fu => fu!.LevelFocusModel)
                        .ThenInclude(lf => lf!.LevelModel)
                .Include(v => v.FocusUniversityModel)
                    .ThenInclude(fu => fu!.LevelFocusModel)
                        .ThenInclude(lf => lf!.FocusModel)
                            .ThenInclude(f => f!.DirectionModel)
                                .ThenInclude(d => d!.GroupModel)
                .Include(v => v.FocusUniversityModel)
                    .ThenInclude(fu => fu!.LevelFocusModel)
                        .ThenInclude(lf => lf!.FocusModel)
                            .ThenInclude(f => f!.AreaFocuss)
                                !.ThenInclude(f => f!.AreaModel)
                .Where(v => v.FocusUniversityModel!.LevelFocusModel!.LevelId == level)
                .Where(v => v.FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionId == direction)
                .ToList();

            // Все "Область"
            List<AreaModel> areaList = variabilityList
                .SelectMany(v => v.FocusUniversityModel!.LevelFocusModel!.FocusModel!.AreaFocuss!)
                .Select(af => af.AreaModel!)
                .Distinct()
                .ToList();

            // Все "Уровень - Направленность"
            List<LevelFocusModel> levelFocusList = variabilityList
                .Select(v => v.FocusUniversityModel!.LevelFocusModel!)
                .Distinct()
                .ToList();

            // Область -> Фильтр
            List<SelectListItem> areaSelectListItem = areaList
                .Select(a => new SelectListItem
                {
                    Text = $"{a.Name} ({levelFocusList.Where(f => f.FocusModel!.AreaFocuss!.Select(af => af.AreaModel).Contains(a)).Count()})",
                    Value = a.Id.ToString(),
                    Selected = a.Id == area
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
                    .Where(f => f.FocusUniversityModel!.LevelFocusModel!.FocusModel!.AreaFocuss!.Select(af => af.AreaModel).Contains(selectArea))
                    .ToList();

                // Все "Уровень - Направленность"
                levelFocusList = variabilityList
                    .Select(v => v.FocusUniversityModel!.LevelFocusModel!)
                    .Distinct()
                    .ToList();
            }

            return View(new FocusSelectionContainerViewModel(variabilityList, levelFocusList, areaSelectListItem, level, direction));
        }
    }
}