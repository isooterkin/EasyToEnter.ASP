using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.ViewsModels.Applicant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EasyToEnter.ASP.Controllers.Applicant
{
    public partial class ApplicantController
    {
        public IActionResult VariabilitySelection(
            [FromQuery(Name = "levelFocus")] int levelFocus,
            [FromQuery(Name = "form")] int? form,
            [FromQuery(Name = "format")] int? format,
            [FromQuery(Name = "payment")] int? payment
            )
        {
            if ((levelFocus <= 0) || 
                (form != null && form <= 0) || 
                (format != null && format <= 0) || 
                (payment != null && payment <= 0)) 
                return NotFound();

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

            // Список форм
            List<FormModel> formList = variabilityList
                .Select(v => v.FormModel!)
                .Distinct()
                .ToList();

            // Список форматов
            List<FormatModel> formatList = variabilityList
                .Select(v => v.FormatModel!)
                .Distinct()
                .ToList();

            // Список оплат
            List<PaymentModel> paymentList = variabilityList
                .Select(v => v.PaymentModel!)
                .Distinct()
                .ToList();

            // Список вступительных экзаменов
            List<string> entranceExamsList = variabilityList
                .Select(v => v.EntranceExams == true ? "Да" : "Нет")
                .Distinct()
                .ToList();

            // Конвертация форм в фильтры
            List<SelectListItem> formSelectList = formList
                .Select(f => new SelectListItem($"{f.Name}", $"{f.Id}"))
                .ToList();

            // Конвертация форматов в фильтры
            List<SelectListItem> formatSelectList = formatList
                .Select(f => new SelectListItem($"{f.Name}", $"{f.Id}"))
                .ToList();

            // Конвертация форматов в фильтры
            List<SelectListItem> paymentSelectList = paymentList
                .Select(f => new SelectListItem($"{f.Name}", $"{f.Id}"))
                .ToList();

            // Конвертация форматов в фильтры
            List<SelectListItem> entranceExamsSelectList = entranceExamsList
                .Select(f => new SelectListItem($"{f}", $"{(f == "Да" ? 1 : 0)}"))
                .ToList();

            return View(new VariabilitySelectionContainerViewModel(variabilityList, formSelectList, formatSelectList, paymentSelectList, entranceExamsSelectList, levelFocus));
        }
    }
}