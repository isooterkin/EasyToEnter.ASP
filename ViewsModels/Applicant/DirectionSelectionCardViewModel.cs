using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class DirectionSelectionCardViewModel
    {
        public readonly DirectionSelectionContainerViewModel DirectionSelectionContainer;
        public readonly DirectionModel Direction;

        public DirectionSelectionCardViewModel(DirectionSelectionContainerViewModel directionSelectionContainer, DirectionModel direction)
        {
            DirectionSelectionContainer = directionSelectionContainer;
            Direction = direction;
        }

        public int LevelFocusCount => DirectionSelectionContainer.LevelFocusCollection.Where(l => l.FocusModel!.DirectionModel == Direction).Count();
        public int LevelId => DirectionSelectionContainer.LevelId;
    }
}