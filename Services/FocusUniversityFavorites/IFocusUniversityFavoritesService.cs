using System.Security.Claims;

namespace EasyToEnter.ASP.Services.FocusUniversityFavorites
{
    public interface IFocusUniversityFavoritesService
    {
        Task<bool> AddFavorites(int focusUniversityId);

        Task<bool> DeleteFavorites(int focusUniversityId);
    }
}