namespace EasyToEnter.ASP.Services.Favorites
{
    public interface IVariabilityFavoritesService
    {
        Task<bool> AddFavorites(int variabilityId);

        Task<bool> DeleteFavorites(int variabilityId);
    }
}