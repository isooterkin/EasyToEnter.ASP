using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class LevelSelectionCardViewModel
    {
        public readonly LevelModel Level;
        public readonly int VariabilityCount;

        public LevelSelectionCardViewModel(LevelSelectionContainerViewModel levelSelectionContainer, LevelModel level)
        {
            Level = level;
            VariabilityCount = levelSelectionContainer.VariabilityList.Where(v => v.FocusUniversityModel!.LevelFocusModel!.LevelModel == level).Count();
        }
    }
}