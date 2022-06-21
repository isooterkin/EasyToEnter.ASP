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
        public async Task<IActionResult> VacancySelection([FromQuery(Name = "profession")] int? profession)
        {
            // Все Вакансии
            List<VacancyModel> vacancyList = await _context.Vacancy
                .Include(v => v.OrganizationModel)
                .Include(v => v.ProfessionModel!.TypeProfessionModel)
                .ToListAsync();

            // Все "Профессии"
            List<ProfessionModel> professionList = vacancyList
                .Select(v => v.ProfessionModel!)
                .Distinct()
                .ToList();

            // "Профессии" -> Фильтр
            List<SelectListItemSubtext> professionSelectListItem = professionList
                .Select(a => new SelectListItemSubtext
                {
                    Text = a.Name.ToString(),
                    Value = a.Id.ToString(),
                    Selected = a.Id == profession,
                    Subtext = vacancyList.Where(v => v.ProfessionId == a.Id).Count().ToString()
                }).ToList();

            // Фильтрация по "Профессии"
            if (profession != null)
            {
                // Выбранная "Профессии"
                ProfessionModel? selectProfession = professionList.FirstOrDefault(p => p.Id == profession);

                // Если "Аккредитация" не существует
                if (selectProfession == null) return NotFound();

                // Фильтруем "Вакансии"
                vacancyList = vacancyList
                    .Where(v => v.ProfessionId == profession)
                    .ToList();
            }

            return View(new VacancySelectionContainerViewModel(vacancyList, professionSelectListItem));
        }
    }
}