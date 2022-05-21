﻿using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.ViewsModels.Applicant;
using EasyToEnter.ASP.ViewsModels.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EasyToEnter.ASP.Controllers.Applicant
{
    public partial class ApplicantController
    {
        public async Task<IActionResult> VariabilitySelection(
            [FromQuery(Name = "levelFocus")] int levelFocus,
            [FromQuery(Name = "form")] int? form,
            [FromQuery(Name = "format")] int? format,
            [FromQuery(Name = "payment")] int? payment,
            [FromQuery(Name = "entranceExams")] int? entranceExams,
            [FromQuery(Name = "accreditation")] int? accreditation,
            [FromQuery(Name = "militaryDepartment")] int? militaryDepartment
            )
        {
            if ((levelFocus <= 0) || 
                (form != null && form <= 0) || 
                (format != null && format <= 0) || 
                (payment != null && payment <= 0)) 
                return NotFound();

            // Все "Вариативность"
            List<VariabilityModel> variabilityList = await _context.Variability
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
                .ToListAsync();

            // Все "Форма"
            List<FormModel> formList = variabilityList
                .Select(v => v.FormModel!)
                .Distinct()
                .ToList();

            // "Форма" -> Фильтр
            List<SelectListItemSubtext> formSelectListItem = formList
                .Select(f => new SelectListItemSubtext
                {
                    Text = f.Name.ToString(),
                    Value = f.Id.ToString(),
                    Selected = f.Id == form,
                    Subtext = variabilityList.Where(v => v.FormId == f.Id).Count().ToString()
                }).ToList();

            // Все "Формат"
            List<FormatModel> formatList = variabilityList
                .Select(v => v.FormatModel!)
                .Distinct()
                .ToList();

            // "Формат" -> Фильтр
            List<SelectListItemSubtext> formatSelectListItem = formatList
                .Select(f => new SelectListItemSubtext
                {
                    Text = f.Name.ToString(),
                    Value = f.Id.ToString(),
                    Selected = f.Id == format,
                    Subtext = variabilityList.Where(v => v.FormatId == f.Id).Count().ToString()
                }).ToList();

            // Все "Оплата"
            List<PaymentModel> paymentList = variabilityList
                .Select(v => v.PaymentModel!)
                .Distinct()
                .ToList();

            // "Оплата" -> Фильтр
            List<SelectListItemSubtext> paymentSelectListItem = paymentList
                .Select(p => new SelectListItemSubtext
                {
                    Text = p.Name.ToString(),
                    Value = p.Id.ToString(),
                    Selected = p.Id == payment,
                    Subtext = variabilityList.Where(v => v.PaymentId == p.Id).Count().ToString()
                }).ToList();

            // Все "Вступительные экзамены" !!! Можно попроще!
            List<bool> entranceExamsList = variabilityList
                .Select(v => v.EntranceExams)
                .Distinct()
                .ToList();

            // "Вступительные экзамены" -> Фильтр
            List<SelectListItemSubtext> entranceExamsSelectListItem = entranceExamsList
                .Select(e => new SelectListItemSubtext
                {
                    Text = e == true ? "Экзамен" : "Без экзамена",
                    Value = e == true ? "1" : "0",
                    Selected = (e == true ? 1 : 0) == entranceExams,
                    Subtext = variabilityList.Where(v => v.EntranceExams == e).Count().ToString()
                }).ToList();

            // Все "Аккредитация"
            List<AccreditationModel> accreditationList = variabilityList
                .Select(v => v.FocusUniversityModel!.UniversityModel!.AccreditationModel!)
                .Distinct()
                .ToList();

            // "Аккредитация" -> Фильтр
            List<SelectListItemSubtext> accreditationSelectListItem = accreditationList
                .Select(a => new SelectListItemSubtext
                {
                    Text = a.Name.ToString(),
                    Value = a.Id.ToString(),
                    Selected = a.Id == accreditation,
                    Subtext = variabilityList.Where(v => v.FocusUniversityModel!.UniversityModel!.AccreditationId == a.Id).Count().ToString()
                }).ToList();

            // Все "Военная кафедра" (militaryDepartment)
            List<bool> militaryDepartmentList = variabilityList
                .Select(v => v.FocusUniversityModel!.UniversityModel!.MilitaryDepartment)
                .Distinct()
                .ToList();

            // "Военная кафедра" -> Фильтр
            List<SelectListItemSubtext> militaryDepartmentSelectListItem = militaryDepartmentList
                .Select(m => new SelectListItemSubtext
                {
                    Text = m == true ? "Есть военная кафедра" : "Нет военной кафедры",
                    Value = m == true ? "1" : "0",
                    Selected = (m == true ? 1 : 0) == militaryDepartment,
                    Subtext = variabilityList.Where(v => v.FocusUniversityModel!.UniversityModel!.MilitaryDepartment == m).Count().ToString()
                }).ToList();

            // Все "Общежитие" (dormitory)


            // "Общежитие" -> Фильтр


            // Все "Специализация" (specializationUniversity)


            // "Специализация" -> Фильтр


            // Все "Субъект" (region)


            // "Субъект" -> Фильтр


            // Все "Город" (city)


            // "Субъект" -> Фильтр



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

            // Фильтрация по "Военная кафедра"
            if (militaryDepartment != null)
                // Фильтруем "Вариативность"
                variabilityList = variabilityList
                    .Where(v => v.FocusUniversityModel!.UniversityModel!.MilitaryDepartment == (militaryDepartment == 1))
                    .ToList();

            return View(new VariabilitySelectionContainerViewModel(variabilityList, formSelectListItem, formatSelectListItem, paymentSelectListItem, entranceExamsSelectListItem, accreditationSelectListItem, militaryDepartmentSelectListItem, levelFocus));
        }
    }
}