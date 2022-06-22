using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.ViewsModels.Applicant;
using EasyToEnter.ASP.ViewsModels.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EasyToEnter.ASP.Tools.Authorization;
using EasyToEnter.ASP.Tools.Authorization.Attributes;

namespace EasyToEnter.ASP.Controllers.Applicant
{
    public partial class ApplicantController
    {
        [SessionCheck]
        public async Task<IActionResult> UniversitySelection(
            [FromQuery(Name = "accreditation")] int? accreditation,
            [FromQuery(Name = "militaryDepartment")] int? militaryDepartment,
            [FromQuery(Name = "dormitory")] int? dormitory,
            [FromQuery(Name = "specialization")] int? specialization
            )
        {
            if (specialization != null && specialization <= 0) return NotFound();

            // Все ВУЗы
            List<UniversityModel> universityList = await _context.University
                .Include(u => u.FocusUniversitys!)
                    .ThenInclude(fu => fu.Variabilitys!)
                        .ThenInclude(v => v.HistoryVariabilitys)
                .Where(u => u.FocusUniversitys!.Any())
                .Include(u => u.AccreditationModel)
                .Include(u => u.Dormitorys)
                .Include(u => u.SpecializationUniversitys!)
                    .ThenInclude(su => su.SpecializationModel)
                .Include(u => u.AddressModel!.CityModel!.RegionModel)
                .Include(u => u.UniversityFavoritess)
                .ToListAsync();

            // Все "Аккредитация"
            List<AccreditationModel> accreditationList = universityList
                .Select(u => u.AccreditationModel!)
                .Distinct()
                .ToList();

            // "Аккредитация" -> Фильтр
            List<SelectListItemSubtext> accreditationSelectListItem = accreditationList
                .Select(a => new SelectListItemSubtext
                {
                    Text = a.Name.ToString(),
                    Value = a.Id.ToString(),
                    Selected = a.Id == accreditation,
                    Subtext = universityList.Where(u => u.AccreditationId == a.Id).Count().ToString()
                }).ToList();

            // Все "Военная кафедра" (militaryDepartment)
            List<bool> militaryDepartmentList = universityList
                .Select(u => u.MilitaryDepartment)
                .Distinct()
                .ToList();

            // "Военная кафедра" -> Фильтр
            List<SelectListItemSubtext> militaryDepartmentSelectListItem = militaryDepartmentList
                .Select(m => new SelectListItemSubtext
                {
                    Text = m == true ? "Есть военная кафедра" : "Нет военной кафедры",
                    Value = m == true ? "1" : "0",
                    Selected = (m == true ? 1 : 0) == militaryDepartment,
                    Subtext = universityList.Where(u => u.MilitaryDepartment == m).Count().ToString()
                }).ToList();

            // Все "Общежитие" (dormitory)
            List<bool> dormitoryList = universityList
                .Select(u => u.Dormitorys!.Any())
                .Distinct()
                .ToList();

            // "Общежитие" -> Фильтр
            List<SelectListItemSubtext> dormitorySelectListItem = dormitoryList
                .Select(d => new SelectListItemSubtext
                {
                    Text = d == true ? "Есть общежитие" : "Нет общежития",
                    Value = d == true ? "1" : "0",
                    Selected = (d == true ? 1 : 0) == dormitory,
                    Subtext = universityList.Where(u => u.Dormitorys!.Any() == d).Count().ToString()
                }).ToList();

            // Все "Специализация" (specialization)
            List<SpecializationModel> specializationList = universityList
                .SelectMany(v => v.SpecializationUniversitys!)
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
                    Subtext = universityList.Where(u => u.SpecializationUniversitys!.Select(su => su.SpecializationModel).Contains(s)).Count().ToString(),
                }).ToList();

            // Все "Субъект" (region)


            // "Субъект" -> Фильтр


            // Все "Город" (city)


            // "Город" -> Фильтр


            // Фильтрация по "Аккредитация"
            if (accreditation != null)
            {
                // Выбранная "Аккредитация"
                AccreditationModel? selectAccreditation = accreditationList.FirstOrDefault(a => a.Id == accreditation);

                // Если "Аккредитация" не существует
                if (selectAccreditation == null) return NotFound();

                // Фильтруем "ВУЗ"
                universityList = universityList
                    .Where(u => u.AccreditationId == accreditation)
                    .ToList();
            }

            // Фильтрация по "Военная кафедра"
            if (militaryDepartment != null)
                // Фильтруем "ВУЗ"
                universityList = universityList
                    .Where(u => u.MilitaryDepartment == (militaryDepartment == 1))
                    .ToList();

            // Фильтрация по "Общежитие"
            if (dormitory != null)
                // Фильтруем "ВУЗ"
                universityList = universityList
                    .Where(u => u.Dormitorys!.Any() == (dormitory == 1))
                    .ToList();

            // Фильтрация по "Специализация"
            if (specialization != null)
            {
                // Выбранная "Специализация"
                SpecializationModel? selectSpecialization = specializationList.FirstOrDefault(s => s.Id == specialization);

                // Если "Специализация" не существует
                if (selectSpecialization == null) return NotFound();

                // Фильтруем "ВУЗ"
                universityList = universityList
                    .Where(u => u.SpecializationUniversitys!.Select(su => su.SpecializationModel).Contains(selectSpecialization))
                    .ToList();
            }

            List<UniversityFavoritesViewModel> universityFavoritesViewModel = new();

            for (var i = 0; i < universityList.Count; i++)
                universityFavoritesViewModel.Add(new UniversityFavoritesViewModel()
                {
                    University = universityList[i]
                });

            if (User.Id() != null)
            {
                PersonModel person = _context.Session
                    .Include(s => s.PersonModel)
                    .Single(s => s.Id == User.SessionId()).PersonModel!;

                for (var i = 0; i < universityList.Count; i++)
                    universityFavoritesViewModel[i].Favorites = universityList[i].UniversityFavoritess!
                        .Any(fuf => fuf.PersonId == person.Id);
            }

            return View(new UniversitySelectionContainerViewModel(universityFavoritesViewModel, accreditationSelectListItem, militaryDepartmentSelectListItem, dormitorySelectListItem, specializationSelectListItem));
        }
    }
}