using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class GroupSelectionContainerViewModel
    {
        public readonly IEnumerable<FocusUniversityModel> FocusUniversityCollection;
        public readonly List<GroupModel> GroupList;
        public readonly int LevelId;

        public GroupSelectionContainerViewModel(IEnumerable<FocusUniversityModel> focusUniversityCollection, List<GroupModel> groupList, int level)
        {
            FocusUniversityCollection = focusUniversityCollection;
            GroupList = groupList;
            LevelId = level;
        }
    }
}