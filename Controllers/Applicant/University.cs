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
                .Include(v => v.FocusUniversityModel!.UniversityModel!.AccreditationModel)
                .Where(v => v.FocusUniversityModel!.UniversityId == university)
                .Include(v => v.FocusUniversityModel!.UniversityModel!.AddressModel!.CityModel!.RegionModel)
                .Include(v => v.FocusUniversityModel!.UniversityModel!.Dormitorys!)
                    .ThenInclude(d => d!.AddressModel)
                .Include(v => v.FocusUniversityModel!.UniversityModel!.PhoneNumbers)
                .ToList();

            if (!variabilityList.Any()) return NotFound();

            return View(new UniversityViewModel(variabilityList));
        }
    }
}