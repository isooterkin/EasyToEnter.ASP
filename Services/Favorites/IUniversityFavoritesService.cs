namespace EasyToEnter.ASP.Services.Favorites
{
    public interface IUniversityFavoritesService
    {
        Task<bool> AddFavorites(int universityId);

        Task<bool> DeleteFavorites(int universityId);
    }
}