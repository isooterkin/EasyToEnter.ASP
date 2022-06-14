using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.Services.Vacancy
{
    public interface IVacancyService
    {
        Task<bool> DeleteVacancy(int vacancyId);

        Task<bool> DeleteVacancy(VacancyModel vacancy);
    }
}