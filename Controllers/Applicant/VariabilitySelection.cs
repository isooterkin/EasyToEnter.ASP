using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.ViewsModels.Applicant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyToEnter.ASP.Controllers.Applicant
{
    public partial class ApplicantController
    {
        public IActionResult VariabilitySelection([FromQuery(Name = "levelFocus")] int levelFocus)
        {
            if (levelFocus <= 0) return NotFound();

            List<VariabilityModel> variabilityList = _context.Variability
                .Include(v => v.FormModel)
                .Include(v => v.FormatModel)
                .Include(v => v.PaymentModel)
                .Include(v => v.FocusUniversityModel)
                    .ThenInclude(fu => fu!.LevelFocusModel)
                        .ThenInclude(lf => lf!.LevelModel)
                .Include(v => v.FocusUniversityModel)
                    .ThenInclude(fu => fu!.LevelFocusModel)
                        .ThenInclude(lf => lf!.FocusModel)
                            .ThenInclude(f => f!.DirectionModel)
                                .ThenInclude(d => d!.GroupModel)
                .Include(v => v.FocusUniversityModel)
                    .ThenInclude(fu => fu!.UniversityModel)
                        .ThenInclude(u => u!.AccreditationModel)
                .Include(v => v.FocusUniversityModel)
                    .ThenInclude(fu => fu!.UniversityModel)
                        .ThenInclude(u => u!.CityModel)
                .Include(v => v.FocusUniversityModel)
                    .ThenInclude(fu => fu!.UniversityModel)
                        .ThenInclude(u => u!.Dormitorys)
                .Include(v => v.FocusUniversityModel)
                    .ThenInclude(fu => fu!.UniversityModel)
                        .ThenInclude(u => u!.SpecializationUniversitys)
                            !.ThenInclude(su => su.SpecializationModel)
                .Where(v => v.FocusUniversityModel!.LevelFocusId == levelFocus)
                .ToList();

            return View(new VariabilitySelectionContainerViewModel(variabilityList, levelFocus));
        }
    }
}