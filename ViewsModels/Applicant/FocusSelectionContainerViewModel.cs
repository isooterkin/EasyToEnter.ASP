using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class FocusSelectionContainerViewModel
    {
        public readonly List<FocusModel?> FocusList;
        public readonly IEnumerable<LevelFocusModel> LevelFocusCollection;
        public readonly int LevelId;

        public FocusSelectionContainerViewModel(IEnumerable<LevelFocusModel> levelFocusCollection, int level)
        {
            FocusList = levelFocusCollection.Select(g => g!.FocusModel).Distinct().ToList();
            LevelFocusCollection = levelFocusCollection;
            LevelId = level;
        }
    }
}