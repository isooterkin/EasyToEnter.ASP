using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class DirectionSelectionContainerViewModel
    {
        public readonly List<DirectionModel?> DirectionList;
        public readonly IEnumerable<LevelFocusModel> LevelFocusCollection;
        public readonly int LevelId;

        public DirectionSelectionContainerViewModel(IEnumerable<LevelFocusModel> levelFocusCollection, int level, int group)
        {
            DirectionList = levelFocusCollection.Select(g => g!.FocusModel!.DirectionModel).Distinct().ToList();
            LevelFocusCollection = levelFocusCollection;
            LevelId = level;
        }
    }
}