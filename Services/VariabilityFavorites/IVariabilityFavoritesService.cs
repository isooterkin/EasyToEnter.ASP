namespace EasyToEnter.ASP.Services.VariabilityFavorites
{
    public interface IVariabilityFavoritesService
    {
        Task<bool> AddFavorites(int variabilityId);

        Task<bool> DeleteFavorites(int variabilityId);
    }
}