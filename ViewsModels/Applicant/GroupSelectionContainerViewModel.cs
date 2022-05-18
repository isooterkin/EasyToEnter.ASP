using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class GroupSelectionContainerViewModel
    {
        public readonly List<VariabilityModel> VariabilityList;
        public readonly List<GroupModel> GroupList;
        public readonly int LevelId;

        public GroupSelectionContainerViewModel(List<VariabilityModel> variabilityList, List<GroupModel> groupList, int level)
        {
            VariabilityList = variabilityList;
            GroupList = groupList;
            LevelId = level;
        }
    }
}