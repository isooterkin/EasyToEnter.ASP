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
            [FromQuery(Name = "payment")] int? payment,
            [FromQuery(Name = "entranceExams")] int? entranceExams,
            [FromQuery(Name = "accreditation")] int? accreditation
            )
        {
            if ((levelFocus <= 0) || 
                (form != null && form <= 0) || 
                (format != null && format <= 0) || 
                (payment != null && payment <= 0)) 
                return NotFound();

            // Все "Вариативность"
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

            // Все "Форма"
            List<FormModel> formList = variabilityList
                .Select(v => v.FormModel!)
                .Distinct()
                .ToList();

            // "Форма" -> Фильтр
            List<SelectListItem> formSelectListItem = formList
                .Select(f => new SelectListItem
                {
                    Text = $"Форма: {f.Name} ({variabilityList.Where(v => v.FormId == f.Id).Count()})",
                    Value = f.Id.ToString(),
                    Selected = f.Id == form
                }).ToList();

            // Все "Формат"
            List<FormatModel> formatList = variabilityList
                .Select(v => v.FormatModel!)
                .Distinct()
                .ToList();

            // "Формат" -> Фильтр
            List<SelectListItem> formatSelectListItem = formatList
                .Select(f => new SelectListItem
                {
                    Text = $"Формат: {f.Name} ({variabilityList.Where(v => v.FormatId == f.Id).Count()})",
                    Value = f.Id.ToString(),
                    Selected = f.Id == format
                }).ToList();

            // Все "Оплата"
            List<PaymentModel> paymentList = variabilityList
                .Select(v => v.PaymentModel!)
                .Distinct()
                .ToList();

            // "Оплата" -> Фильтр
            List<SelectListItem> paymentSelectListItem = paymentList
                .Select(p => new SelectListItem
                {
                    Text = $"Оплата: {p.Name} ({variabilityList.Where(v => v.PaymentId == p.Id).Count()})",
                    Value = p.Id.ToString(),
                    Selected = p.Id == payment
                }).ToList();

            // Все "Вступительные экзамены" !!! Можно попроще!
            List<bool> entranceExamsList = variabilityList
                .Select(v => v.EntranceExams)
                .Distinct()
                .ToList();

            // "Вступительные экзамены" -> Фильтр
            List<SelectListItem> entranceExamsSelectListItem = entranceExamsList
                .Select(e => new SelectListItem
                {
                    Text = $"Экзамены: {(e == true ? "Да" : "Нет")} ({variabilityList.Where(v => v.EntranceExams == e).Count()})",
                    Value = $"{(e == true ? 1 : 0)}",
                    Selected = (e == true ? 1 : 0) == entranceExams
                }).ToList();

            // Все "Аккредитация"
            List<AccreditationModel> accreditationList = variabilityList
                .Select(v => v.FocusUniversityModel!.UniversityModel!.AccreditationModel!)
                .Distinct()
                .ToList();

            // "Аккредитация" -> Фильтр
            List<SelectListItem> accreditationSelectListItem = accreditationList
                .Select(a => new SelectListItem
                {
                    Text = $"Аккредитация: {a.Name} ({variabilityList.Where(v => v.FocusUniversityModel!.UniversityModel!.AccreditationId == a.Id).Count()})",
                    Value = a.Id.ToString(),
                    Selected = a.Id == accreditation
                }).ToList();

            // militaryDepartment
            // dormitory
            // specializationUniversity
            // region
            // city

            // tuition
            // passingGrade

            // Фильтрация по "Форма"
            if (form != null) 
            {
                // Выбранная "Форма"
                FormModel? selectForm = formList.FirstOrDefault(f => f.Id == form);

                // Если "Форма" не существует
                if (selectForm == null) return NotFound();

                // Фильтруем "Вариативность"
                variabilityList = variabilityList
                    .Where(v => v.FormId == form)
                    .ToList();
            }

            // Фильтрация по "Формат"
            if (format != null) 
            {
                // Выбранный "Формат"
                FormatModel? selectFormat = formatList.FirstOrDefault(f => f.Id == format);

                // Если "Форма" не существует
                if (selectFormat == null) return NotFound();

                // Фильтруем "Вариативность"
                variabilityList = variabilityList
                    .Where(v => v.FormatId == format)
                    .ToList();
            }

            // Фильтрация по "Оплата"
            if (payment != null) 
            {
                // Выбранная "Оплата"
                PaymentModel? selectPayment = paymentList.FirstOrDefault(p => p.Id == payment);

                // Если "Форма" не существует
                if (selectPayment == null) return NotFound();

                // Фильтруем "Вариативность"
                variabilityList = variabilityList
                    .Where(v => v.PaymentId == payment)
                    .ToList();
            }

            // Фильтрация по "Вступительные экзамены"
            if (entranceExams != null) 
                // Фильтруем "Вариативность"
                variabilityList = variabilityList
                    .Where(v => v.EntranceExams == (entranceExams == 1) )
                    .ToList();

            // Фильтрация по "Аккредитация"
            if (accreditation != null)
            {
                // Выбранная "Аккредитация"
                AccreditationModel? selectAccreditation = accreditationList.FirstOrDefault(a => a.Id == accreditation);

                // Если "Аккредитация" не существует
                if (selectAccreditation == null) return NotFound();

                // Фильтруем "Вариативность"
                variabilityList = variabilityList
                    .Where(v => v.FocusUniversityModel!.UniversityModel!.AccreditationId == accreditation)
                    .ToList();
            }

            return View(new VariabilitySelectionContainerViewModel(variabilityList, formSelectListItem, formatSelectListItem, paymentSelectListItem, entranceExamsSelectListItem, accreditationSelectListItem, levelFocus));
        }
    }
}