using EasyToEnter.ASP.Models.Models;
using Newtonsoft.Json;

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