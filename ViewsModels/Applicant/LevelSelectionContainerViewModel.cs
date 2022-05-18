using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class LevelSelectionContainerViewModel
    {
        public readonly List<VariabilityModel> VariabilityList;
        public readonly List<LevelModel> LevelList;

        public LevelSelectionContainerViewModel(List<VariabilityModel> variabilityList, List<LevelModel> levelList)
        {
            VariabilityList = variabilityList;
            LevelList = levelList;
        }
    }
}