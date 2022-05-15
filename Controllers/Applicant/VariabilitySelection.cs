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

            IEnumerable<FocusUniversityModel> focusUniversityCollection = _context.FocusUniversity
                .Include(fu => fu.LevelFocusModel)
                    .ThenInclude(lf => lf!.LevelModel)
                .Include(fu => fu.LevelFocusModel)
                    .ThenInclude(lf => lf!.FocusModel)
                        .ThenInclude(f => f!.DirectionModel)
                            .ThenInclude(d => d!.GroupModel)
                .Include(fu => fu.Variabilitys)
                    !.ThenInclude(v => v.FormatModel)
                .Include(fu => fu.Variabilitys)
                    !.ThenInclude(v => v.FormModel)
                .Include(fu => fu.Variabilitys)
                    !.ThenInclude(v => v.PaymentModel)
                .Include(fu => fu.UniversityModel)
                    .ThenInclude(u => u!.AccreditationModel)
                .Include(fu => fu.UniversityModel)
                    .ThenInclude(u => u!.CityModel)
                        .ThenInclude(c => c!.RegionModel)
                .Include(fu => fu.UniversityModel)
                    .ThenInclude(u => u!.Dormitorys)
                .Include(fu => fu.UniversityModel)
                    .ThenInclude(u => u!.SpecializationUniversitys)
                        !.ThenInclude(su => su!.SpecializationModel)
                .Where(fu => fu!.LevelFocusId == levelFocus);

            return View();
        }
    }
}