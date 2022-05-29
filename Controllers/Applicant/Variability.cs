using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyToEnter.ASP.Controllers.Applicant
{
    public partial class ApplicantController : Controller
    {
        public IActionResult Variability([FromQuery(Name = "variability")] int variability)
        {
            if (variability <= 0) return NotFound();

            // "Вариативность"
            VariabilityModel? variabilityModel = _context.Variability
                .Where(v => v.Id == variability)
                .Include(v => v.FormatModel)
                .Include(v => v.FormModel)
                .Include(v => v.PaymentModel)
                .Include(v => v.HistoryVariabilitys)
                .Include(v => v.FocusUniversityModel)
                    .ThenInclude(fu => fu!.DisciplineFocusUniversitys)
                        !.ThenInclude(dfu => dfu!.DisciplineModel)
                .Include(v => v.FocusUniversityModel)
                    .ThenInclude(fu => fu!.LevelFocusModel)
                        .ThenInclude(lf => lf!.LevelModel)
                .Include(v => v.FocusUniversityModel)
                    .ThenInclude(fu => fu!.LevelFocusModel)
                        .ThenInclude(lf => lf!.FocusModel)
                            .ThenInclude(f => f!.DirectionModel)
                                .ThenInclude(d => d!.GroupModel)
                                    .ThenInclude(g => g!.ScienceModel)
                .First();

            return View(variabilityModel);
        }
    }
}