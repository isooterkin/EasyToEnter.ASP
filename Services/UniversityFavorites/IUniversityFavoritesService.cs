namespace EasyToEnter.ASP.Services.UniversityFavorites
{
    public interface IUniversityFavoritesService
    {
        Task<bool> AddFavorites(int universityId);

        Task<bool> DeleteFavorites(int universityId);
    }
}