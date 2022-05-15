using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class ScienceSelectionCardViewModel
    {
        public readonly ScienceModel Science;
        public readonly int FocusUniversityCount;
        public readonly int LevelId;

        public ScienceSelectionCardViewModel(ScienceSelectionContainerViewModel scienceSelectionContainer, ScienceModel science)
        {
            Science = science;
            FocusUniversityCount = scienceSelectionContainer.FocusUniversityCollection.Where(f => f.LevelFocusModel!.FocusModel!.DirectionModel!.GroupModel!.ScienceModel == science).Count();
            LevelId = scienceSelectionContainer.LevelId;
        }
    }
}