using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class VariabilitySelectionContainerViewModel
    {
        public readonly List<VariabilityModel> VariabilityList;
        public readonly int LevelFocusId;

        public VariabilitySelectionContainerViewModel(List<VariabilityModel> variabilityList, int levelFocus)
        {
            VariabilityList = variabilityList;
            LevelFocusId = levelFocus;
        }
    }
}