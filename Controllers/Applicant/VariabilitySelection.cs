using EasyToEnter.ASP.Controllers.Authorization;
using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.ViewsModels.Applicant;
using EasyToEnter.ASP.ViewsModels.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EasyToEnter.ASP.Tools;

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
            [FromQuery(Name = "militaryDepartment")] int? militaryDepartment,
            [FromQuery(Name = "dormitory")] int? dormitory,
            [FromQuery(Name = "specialization")] int? specialization
            )
        {
            if ((levelFocus <= 0) || 
                (form != null && form <= 0) || 
                (format != null && format <= 0) || 
                (payment != null && payment <= 0) ||
                (specialization != null && specialization <=0))
                return NotFound();

            // Все "Вариативность"
            List<VariabilityModel> variabilityList = await _context.Variability
                .Include(v => v.FormModel)
                .Include(v => v.FormatModel)
                .Include(v => v.PaymentModel)
                .Include(v => v.HistoryVariabilitys)
                .Include(v => v.FocusUniversityModel)
                    .ThenInclude(fu => fu!.FocusUniversityFavoritess)
                .Include(v => v.FocusUniversityModel)
                    .ThenInclude(fu => fu!.LevelFocusModel)
                        .ThenInclude(lf => lf!.LevelModel)
                .Include(v => v.FocusUniversityModel)
                    .ThenInclude(fu => fu!.LevelFocusModel)
                        .ThenInclude(lf => lf!.FocusModel)
                            .ThenInclude(f => f!.DirectionModel)
                                .ThenInclude(d => d!.GroupModel)
                                    .ThenInclude(g => g!.ScienceModel)
                .Include(v => v.FocusUniversityModel)
                    .ThenInclude(fu => fu!.UniversityModel)
                        .ThenInclude(u => u!.AccreditationModel)
                .Include(v => v.FocusUniversityModel)
                    .ThenInclude(fu => fu!.UniversityModel)
                .Include(v => v.FocusUniversityModel)
                    .ThenInclude(fu => fu!.UniversityModel)
                        .ThenInclude(u => u!.Dormitorys)
                .Include(v => v.FocusUniversityModel)
                    .ThenInclude(fu => fu!.UniversityModel)
                        .ThenInclude(u => u!.SpecializationUniversitys)
                            !.ThenInclude(su => su.SpecializationModel)
                .Include(v => v.FocusUniversityModel)
                    .ThenInclude(fu => fu!.UniversityModel)
                        .ThenInclude(u => u!.AddressModel)
                            .ThenInclude(a => a!.CityModel)
                                .ThenInclude(c => c!.RegionModel)
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
            List<bool> dormitoryList = variabilityList
                .Select(v => v.FocusUniversityModel!.UniversityModel!.Dormitorys!.Any())
                .Distinct()
                .ToList();

            // "Общежитие" -> Фильтр
            List<SelectListItemSubtext> dormitorySelectListItem = dormitoryList
                .Select(d => new SelectListItemSubtext
                {
                    Text = d == true ? "Есть общежитие" : "Нет общежития",
                    Value = d == true ? "1" : "0",
                    Selected = (d == true ? 1 : 0) == dormitory,
                    Subtext = variabilityList.Where(v => v.FocusUniversityModel!.UniversityModel!.Dormitorys!.Any() == d).Count().ToString()
                }).ToList();

            // Все "Специализация" (specialization)
            List<SpecializationModel> specializationList = variabilityList
                .SelectMany(v => v.FocusUniversityModel!.UniversityModel!.SpecializationUniversitys!)
                .Select(su => su.SpecializationModel!)
                .Distinct()
                .ToList();

            // "Специализация" -> Фильтр
            List<SelectListItemSubtext> specializationSelectListItem = specializationList
                .Select(s => new SelectListItemSubtext
                {
                    Text = s.Name.ToString(),
                    Value = s.Id.ToString(),
                    Selected = s.Id == specialization,
                    Subtext = variabilityList.Where(v => v .FocusUniversityModel!.UniversityModel!.SpecializationUniversitys!.Select(su => su.SpecializationModel).Contains(s)).Count().ToString(),
                }).ToList();

            // Все "Субъект" (region)


            // "Субъект" -> Фильтр


            // Все "Город" (city)


            // "Город" -> Фильтр


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

            // Фильтрация по "Общежитие"
            if (dormitory != null)
                // Фильтруем "Вариативность"
                variabilityList = variabilityList
                    .Where(v => v.FocusUniversityModel!.UniversityModel!.Dormitorys!.Any() == (dormitory == 1))
                    .ToList();

            // Фильтрация по "Специализация"
            if (specialization != null)
            {
                // Выбранная "Специализация"
                SpecializationModel? selectSpecialization = specializationList.FirstOrDefault(s => s.Id == specialization);

                // Если "Специализация" не существует
                if (selectSpecialization == null) return NotFound();

                // Фильтруем "Вариативность"
                variabilityList = variabilityList
                    .Where(v => v.FocusUniversityModel!.UniversityModel!.SpecializationUniversitys!.Select(su => su.SpecializationModel).Contains(selectSpecialization))
                    .ToList();
            }

            List<VariabilityViewModel> variabilityViewModelList = new();


            if (User != null)
            {
                Guid? sessionId = IdentityAssistant.SessionId(User);

                if (sessionId != null)
                {

                    PersonModel person = _context.Session.Include(s => s.PersonModel).Single(s => s.Id == sessionId).PersonModel!;

                    for (var i = 0; i < variabilityList.Count; i++)
                        variabilityViewModelList.Add(new VariabilityViewModel()
                        {
                            Id = variabilityList[i].Id,
                            EntranceExams = variabilityList[i].EntranceExams,
                            FocusUniversityId = variabilityList[i].FocusUniversityId,
                            FormatId = variabilityList[i].FormatId,
                            FormId = variabilityList[i].FormId,
                            PaymentId = variabilityList[i].PaymentId,
                            TrainingPeriod = variabilityList[i].TrainingPeriod,
                            FocusUniversityModel = variabilityList[i].FocusUniversityModel,
                            FormatModel = variabilityList[i].FormatModel,
                            FormModel = variabilityList[i].FormModel,
                            PaymentModel = variabilityList[i].PaymentModel,
                            HistoryVariabilitys = variabilityList[i].HistoryVariabilitys,
                            Favorites = variabilityList[i].FocusUniversityModel!.FocusUniversityFavoritess!.Any(fuf => fuf.PersonId == person.Id)
                        });
                }
            }

            return View(new VariabilitySelectionContainerViewModel(variabilityViewModelList, formSelectListItem, formatSelectListItem, paymentSelectListItem, entranceExamsSelectListItem, accreditationSelectListItem, militaryDepartmentSelectListItem, dormitorySelectListItem, specializationSelectListItem, levelFocus));
        }
    }
}