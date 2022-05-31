using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.ViewsModels.Applicant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyToEnter.ASP.Controllers.Applicant
{
    public partial class ApplicantController
    {
        public IActionResult University([FromQuery(Name = "university")] int university)
        {
            if (university <= 0) return NotFound();

            // "Вариативность"
            List<VariabilityModel> variabilityList = _context.Variability
                .Include(v => v.HistoryVariabilitys) // Возможно историю выведу!
                .Include(v => v.FocusUniversityModel)
                    .ThenInclude(fu => fu!.UniversityModel)
                        .ThenInclude(u => u!.AccreditationModel)
                .Include(v => v.FocusUniversityModel)
                    .ThenInclude(fu => fu!.UniversityModel)
                        .ThenInclude(u => u!.AddressModel)
                            .ThenInclude(a => a!.CityModel)
                                .ThenInclude(c => c!.RegionModel)
                .Include(v => v.FocusUniversityModel)
                    .ThenInclude(fu => fu!.UniversityModel)
                        .ThenInclude(u => u!.Dormitorys)
                            !.ThenInclude(d => d!.AddressModel)
                .Include(v => v.FocusUniversityModel)
                    .ThenInclude(fu => fu!.UniversityModel)
                        .ThenInclude(u => u!.PhoneNumbers)
                .Where(v => v.FocusUniversityModel!.UniversityId == university)
                .ToList();

            if (!variabilityList.Any()) return NotFound();

            return View(new UniversityViewModel(variabilityList));
        }
    }
}