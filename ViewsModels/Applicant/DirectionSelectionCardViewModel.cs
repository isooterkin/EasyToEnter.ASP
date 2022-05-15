using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class DirectionSelectionCardViewModel
    {
        public readonly DirectionModel Direction;
        public readonly int FocusUniversityCount;
        public readonly int LevelId;

        public DirectionSelectionCardViewModel(DirectionSelectionContainerViewModel directionSelectionContainer, DirectionModel direction)
        {
            Direction = direction;
            FocusUniversityCount = directionSelectionContainer.FocusUniversityCollection.Where(f => f.LevelFocusModel!.FocusModel!.DirectionModel == direction).Count();
            LevelId = directionSelectionContainer.LevelId;
        }
    }
}