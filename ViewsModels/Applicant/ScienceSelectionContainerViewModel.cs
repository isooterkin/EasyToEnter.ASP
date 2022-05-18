using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class ScienceSelectionContainerViewModel
    {
        public readonly List<VariabilityModel> VariabilityList;
        public readonly List<ScienceModel> ScienceList;
        public readonly int LevelId;

        public ScienceSelectionContainerViewModel(List<VariabilityModel> variabilityList, List<ScienceModel> scienceList, int level)
        {
            VariabilityList = variabilityList;
            ScienceList = scienceList;
            LevelId = level;
        }
    }
}