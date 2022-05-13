using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class FocusSelectionContainerViewModel
    {
        public readonly List<FocusModel?> FocusList;
        public readonly IEnumerable<LevelFocusModel> LevelFocusCollection;
        public readonly IEnumerable<FocusUniversityModel> FocusUniversityCollection;
        public readonly int LevelId;

        public FocusSelectionContainerViewModel(IEnumerable<LevelFocusModel> levelFocusCollection, IEnumerable<FocusUniversityModel> focusUniversityCollection, int level)
        {
            FocusList = levelFocusCollection.Select(g => g!.FocusModel).Distinct().ToList();
            LevelFocusCollection = levelFocusCollection;
            FocusUniversityCollection = focusUniversityCollection;
            LevelId = level;
        }
    }
}