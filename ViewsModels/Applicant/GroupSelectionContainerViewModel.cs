using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class GroupSelectionContainerViewModel
    {
        public readonly List<GroupModel?> GroupList;
        public readonly IEnumerable<LevelFocusModel> LevelFocusCollection;
        public readonly int LevelId;

        public GroupSelectionContainerViewModel(IEnumerable<LevelFocusModel> levelFocusCollection, int level, int science)
        {
            GroupList = levelFocusCollection.Select(g => g!.FocusModel!.DirectionModel!.GroupModel).Distinct().ToList();
            LevelFocusCollection = levelFocusCollection;
            LevelId = level;
        }
    }
}