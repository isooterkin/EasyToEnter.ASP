using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class GroupSelectionContainerViewModel
    {
        public readonly List<VariabilityModel> VariabilityList;
        public readonly List<GroupModel> GroupList;
        public readonly int LevelId;
        public readonly string LevelName;
        public readonly string ScienceName;

        public GroupSelectionContainerViewModel(List<VariabilityModel> variabilityList, List<GroupModel> groupList, int level)
        {
            VariabilityList = variabilityList;
            GroupList = groupList;
            LevelId = level;
            LevelName = variabilityList.Count > 0 ? variabilityList[0].FocusUniversityModel!.LevelFocusModel!.LevelModel!.Name : "???";
            ScienceName = GroupList.Count > 0 ? GroupList[0].ScienceModel!.Name : "???";
        }
    }
}