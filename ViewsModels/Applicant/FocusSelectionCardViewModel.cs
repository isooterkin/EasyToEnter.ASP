using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class FocusSelectionCardViewModel
    {
        public readonly LevelFocusModel LevelFocus;
        public readonly int FocusUniversityCount;

        public FocusSelectionCardViewModel(FocusSelectionContainerViewModel focusSelectionContainer, LevelFocusModel levelFocus)
        {
            LevelFocus = levelFocus;
            FocusUniversityCount = focusSelectionContainer.FocusUniversityCollection.Where(f => f.LevelFocusModel == levelFocus).Count();
        }
    }
}