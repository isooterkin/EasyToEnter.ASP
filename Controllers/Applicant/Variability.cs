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
                .Include(v => v.FocusUniversityModel!.DisciplineFocusUniversitys!)
                    .ThenInclude(dfu => dfu!.DisciplineModel)
                .Include(v => v.FocusUniversityModel!.LevelFocusModel!.LevelModel)
                .Include(v => v.FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionModel!.GroupModel!.ScienceModel)
                .Include(v => v.FocusUniversityModel!.UniversityModel)
                .Include(v => v.FocusUniversityModel!.SubjectFocusUniversitys!)
                    .ThenInclude(sfu => sfu!.SubjectModel)
                .Include(v => v.FocusUniversityModel!.SubjectFocusUniversitys!)
                    .ThenInclude(sfu => sfu!.SubjectReplacements!)
                        .ThenInclude(sr => sr!.SubjectModel)
                .FirstOrDefault();

            if (variabilityModel == null) return NotFound();

            return View(variabilityModel);
        }
    }
}