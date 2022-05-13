using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class FocusSelectionCardViewModel
    {
        public readonly FocusSelectionContainerViewModel FocusSelectionContainer;
        public readonly FocusModel Focus;

        public FocusSelectionCardViewModel(FocusSelectionContainerViewModel focusSelectionContainer, FocusModel focus)
        {
            FocusSelectionContainer = focusSelectionContainer;
            Focus = focus;
        }

        public int FocusUniversityCount => FocusSelectionContainer.FocusUniversityCollection.Where(l => l.LevelFocusModel!.FocusModel == Focus).Count();
        public int LevelId => FocusSelectionContainer.LevelId;
    }
}