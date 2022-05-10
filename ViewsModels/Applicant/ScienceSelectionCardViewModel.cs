using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class ScienceSelectionCardViewModel
    {
        public readonly ScienceSelectionContainerViewModel ScienceSelectionContainer;
        public readonly ScienceModel Science;

        public ScienceSelectionCardViewModel(ScienceSelectionContainerViewModel scienceSelectionContainer, ScienceModel science)
        {
            ScienceSelectionContainer = scienceSelectionContainer;
            Science = science;
        }

        public int LevelFocusCount => ScienceSelectionContainer.LevelFocusCollection.Where(l => l.FocusModel!.DirectionModel!.GroupModel!.ScienceModel == Science).Count();
        public int LevelId => ScienceSelectionContainer.LevelId;
    }
}