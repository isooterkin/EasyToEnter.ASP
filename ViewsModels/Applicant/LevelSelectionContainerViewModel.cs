using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class LevelSelectionContainerViewModel
    {
        public readonly IEnumerable<FocusUniversityModel> FocusUniversityCollection;
        public readonly List<LevelModel> LevelList;

        public LevelSelectionContainerViewModel(IEnumerable<FocusUniversityModel> focusUniversityCollection, List<LevelModel> levelList)
        {
            FocusUniversityCollection = focusUniversityCollection;
            LevelList = levelList;
        }
    }
}