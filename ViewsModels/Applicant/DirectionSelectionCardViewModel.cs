using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class DirectionSelectionCardViewModel
    {
        public readonly DirectionModel Direction;
        public readonly int VariabilityCount;
        public readonly int LevelId;
        public readonly string FullCodeName;

        public DirectionSelectionCardViewModel(DirectionSelectionContainerViewModel directionSelectionContainer, DirectionModel direction)
        {
            Direction = direction;
            VariabilityCount = directionSelectionContainer.VariabilityList.Where(f => f.FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionModel == direction).Count();
            LevelId = directionSelectionContainer.LevelId;
            FullCodeName = directionSelectionContainer.VariabilityList.Any() ? $"{direction.GroupModel?.Code}.{directionSelectionContainer.VariabilityList[0].FocusUniversityModel!.LevelFocusModel!.LevelModel!.Code}.{direction.Code} {direction.GroupModel!.Name}" : "???";
        }
    }
}