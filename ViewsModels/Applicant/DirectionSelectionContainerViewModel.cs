using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class DirectionSelectionContainerViewModel
    {
        public readonly List<VariabilityModel> VariabilityList;
        public readonly List<DirectionModel> DirectionList;
        public readonly int LevelId;
        public readonly string LevelName = string.Empty;
        public readonly string ScienceName = string.Empty;
        public readonly string GroupName = string.Empty;
        public readonly int ScienceId = 0;

        public DirectionSelectionContainerViewModel(List<VariabilityModel> variabilityList, List<DirectionModel> directionList, int level)
        {
            VariabilityList = variabilityList;
            DirectionList = directionList;
            LevelId = level;

            if (!VariabilityList.Any()) return;

            LevelName = variabilityList[0].FocusUniversityModel!.LevelFocusModel!.LevelModel!.Name;
            ScienceName = DirectionList[0].GroupModel!.ScienceModel!.Name;
            GroupName = DirectionList[0].GroupModel!.Name;
            ScienceId = DirectionList[0].GroupModel!.ScienceId;
        }
    }
}