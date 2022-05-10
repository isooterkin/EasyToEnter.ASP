using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class ScienceSelectionContainerViewModel
    {
        public readonly List<ScienceModel?> ScienceList;
        public readonly IEnumerable<LevelFocusModel> LevelFocusCollection;
        public readonly int LevelId;

        public ScienceSelectionContainerViewModel(IEnumerable<LevelFocusModel> levelFocusCollection, int level)
        {
            ScienceList = levelFocusCollection.Select(g => g!.FocusModel!.DirectionModel!.GroupModel!.ScienceModel).Distinct().ToList();
            LevelFocusCollection = levelFocusCollection;
            LevelId = level;
        }
    }
}