using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class ScienceSelectionCardViewModel
    {
        public readonly ScienceModel Science;
        public readonly int LevelFocusCount;

        public ScienceSelectionCardViewModel(ScienceModel science, int levelFocusCount)
        {
            Science = science;
            LevelFocusCount = levelFocusCount;
        }
    }
}