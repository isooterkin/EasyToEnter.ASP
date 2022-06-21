using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.Services.Favorites
{
    public interface IVacancyFavoritesService
    {
        Task<bool> AddFavorites(VacancyModel vacancy);

        Task<bool> DeleteFavorites(VacancyModel vacancy);
    }
}