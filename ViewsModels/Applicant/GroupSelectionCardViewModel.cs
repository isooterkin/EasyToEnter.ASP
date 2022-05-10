using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class GroupSelectionCardViewModel
    {
        public readonly GroupSelectionContainerViewModel GroupSelectionContainer;
        public readonly GroupModel Group;

        public GroupSelectionCardViewModel(GroupSelectionContainerViewModel groupSelectionContainer, GroupModel group)
        {
            GroupSelectionContainer = groupSelectionContainer;
            Group = group;
        }

        public int LevelFocusCount => GroupSelectionContainer.LevelFocusCollection.Where(l => l.FocusModel!.DirectionModel!.GroupModel == Group).Count();
        public int LevelId => GroupSelectionContainer.LevelId;
        public int ScienceId => GroupSelectionContainer.ScienceId;
    }
}
