using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Components.Maps
{
    public class MapCardViewModel
    {
        public readonly List<UniversityModel> UniversityModelList;

        public MapCardViewModel(List<UniversityModel> universityModelList)
        {
            UniversityModelList = universityModelList;
        }
    }
}