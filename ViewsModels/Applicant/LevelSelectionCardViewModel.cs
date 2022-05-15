using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class LevelSelectionCardViewModel
    {
        public readonly LevelModel Level;
        public readonly int FocusUniversityCount;

        public LevelSelectionCardViewModel(LevelSelectionContainerViewModel levelSelectionContainer, LevelModel level)
        {
            Level = level;
            FocusUniversityCount = levelSelectionContainer.FocusUniversityCollection.Where(f => f.LevelFocusModel!.LevelModel == level).Count();
        }
    }
}