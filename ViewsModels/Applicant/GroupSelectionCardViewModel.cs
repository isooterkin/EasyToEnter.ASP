using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class GroupSelectionCardViewModel
    {
        public readonly GroupModel Group;
        public readonly int FocusUniversityCount;
        public readonly int LevelId;

        public GroupSelectionCardViewModel(GroupSelectionContainerViewModel groupSelectionContainer, GroupModel group)
        {
            Group = group;
            FocusUniversityCount = groupSelectionContainer.FocusUniversityCollection.Where(f => f.LevelFocusModel!.FocusModel!.DirectionModel!.GroupModel == group).Count();
            LevelId = groupSelectionContainer.LevelId;
        }
    }
}