using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class ScienceSelectionCardViewModel
    {
        public readonly ScienceModel Science;
        public readonly int VariabilityCount;
        public readonly int LevelId;

        public ScienceSelectionCardViewModel(ScienceSelectionContainerViewModel scienceSelectionContainer, ScienceModel science)
        {
            Science = science;
            VariabilityCount = scienceSelectionContainer.VariabilityList.Where(v => v.FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionModel!.GroupModel!.ScienceModel == science).Count();
            LevelId = scienceSelectionContainer.LevelId;
        }
    }
}