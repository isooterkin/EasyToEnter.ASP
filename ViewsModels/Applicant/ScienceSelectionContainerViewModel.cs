using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class ScienceSelectionContainerViewModel
    {
        public readonly IEnumerable<FocusUniversityModel> FocusUniversityCollection;
        public readonly List<ScienceModel> ScienceList;
        public readonly int LevelId;

        public ScienceSelectionContainerViewModel(IEnumerable<FocusUniversityModel> focusUniversityCollection, List<ScienceModel> scienceList, int level)
        {
            FocusUniversityCollection = focusUniversityCollection;
            ScienceList = scienceList;
            LevelId = level;
        }
    }
}