using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class GroupSelectionContainerViewModel
    {
        public readonly List<VariabilityModel> VariabilityList;
        public readonly List<GroupModel> GroupList;
        public readonly int LevelId;
        public readonly string LevelName = string.Empty;
        public readonly string ScienceName = string.Empty;

        public GroupSelectionContainerViewModel(List<VariabilityModel> variabilityList, List<GroupModel> groupList, int level)
        {
            VariabilityList = variabilityList;
            GroupList = groupList;
            LevelId = level;

            if (!VariabilityList.Any()) return;

            LevelName = variabilityList[0].FocusUniversityModel!.LevelFocusModel!.LevelModel!.Name;
            ScienceName = GroupList[0].ScienceModel!.Name;
        }
    }
}