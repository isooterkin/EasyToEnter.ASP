using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Account
{
    public class AccountViewModel
    {
        public readonly List<VariabilityFavoritesModel> VariabilityFavoritesList;

        public readonly List<UniversityFavoritesModel> UniversityFavoritesList;

        public AccountViewModel(List<VariabilityFavoritesModel> variabilityFavoritesList, 
            List<UniversityFavoritesModel> universityFavoritesList)
        {
            VariabilityFavoritesList = variabilityFavoritesList;
            UniversityFavoritesList = universityFavoritesList;
        }

        public List<VariabilityModel> VariabilityList => VariabilityFavoritesList.Select(vf => vf.VariabilityModel!).ToList();

        public List<UniversityModel> UniversityList => UniversityFavoritesList.Select(uf => uf.UniversityModel!).ToList();
    }
}