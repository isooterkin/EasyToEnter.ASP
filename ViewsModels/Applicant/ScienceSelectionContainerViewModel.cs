using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class ScienceSelectionContainerViewModel
    {
        public readonly List<VariabilityModel> VariabilityList;
        public readonly List<ScienceModel> ScienceList;
        public readonly int LevelId;
        public readonly string LevelName;

        public ScienceSelectionContainerViewModel(List<VariabilityModel> variabilityList, List<ScienceModel> scienceList, int level)
        {
            VariabilityList = variabilityList;
            ScienceList = scienceList;
            LevelId = level;
            LevelName = variabilityList.Count > 0 ? variabilityList[0].FocusUniversityModel!.LevelFocusModel!.LevelModel!.Name : "???";
        }
    }
}