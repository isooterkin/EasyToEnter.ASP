using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class FocusSelectionCardViewModel
    {
        public readonly LevelFocusModel LevelFocus;
        public readonly int VariabilityCount;

        public FocusSelectionCardViewModel(FocusSelectionContainerViewModel focusSelectionContainer, LevelFocusModel levelFocus)
        {
            LevelFocus = levelFocus;
            VariabilityCount = focusSelectionContainer.VariabilityList.Where(f => f.FocusUniversityModel!.LevelFocusModel == levelFocus).Count();
        }
    }
}