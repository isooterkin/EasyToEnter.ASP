using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class DirectionSelectionContainerViewModel
    {
        public readonly IEnumerable<FocusUniversityModel> FocusUniversityCollection;
        public readonly List<DirectionModel> DirectionList;
        public readonly int LevelId;

        public DirectionSelectionContainerViewModel(IEnumerable<FocusUniversityModel> focusUniversityCollection, List<DirectionModel> directionList, int level)
        {
            FocusUniversityCollection = focusUniversityCollection;
            DirectionList = directionList;
            LevelId = level;
        }
    }
}