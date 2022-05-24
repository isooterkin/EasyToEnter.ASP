using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class GroupSelectionCardViewModel
    {
        public readonly GroupModel Group;
        public readonly int VariabilityCount;
        public readonly int LevelId;
        public readonly string FullCodeName;

        public GroupSelectionCardViewModel(GroupSelectionContainerViewModel groupSelectionContainer, GroupModel group)
        {
            Group = group;
            VariabilityCount = groupSelectionContainer.VariabilityList.Where(v => v.FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionModel!.GroupModel == group).Count();
            LevelId = groupSelectionContainer.LevelId;
            FullCodeName = groupSelectionContainer.VariabilityList.Any() ? $"{group.Code}.{groupSelectionContainer.VariabilityList[0].FocusUniversityModel!.LevelFocusModel!.LevelModel!.Code}.00 {group.ScienceModel!.Name}" : "???";
        }
    }
}