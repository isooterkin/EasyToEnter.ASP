using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class DirectionSelectionContainerViewModel
    {
        public readonly List<VariabilityModel> VariabilityList;
        public readonly List<DirectionModel> DirectionList;
        public readonly int LevelId;
        public readonly string LevelName;
        public readonly string ScienceName;
        public readonly string GroupName;
        public readonly int ScienceId;

        public DirectionSelectionContainerViewModel(List<VariabilityModel> variabilityList, List<DirectionModel> directionList, int level)
        {
            VariabilityList = variabilityList;
            DirectionList = directionList;
            LevelId = level;
            LevelName = variabilityList.Count > 0 ? variabilityList[0].FocusUniversityModel!.LevelFocusModel!.LevelModel!.Name : "???";
            ScienceName = DirectionList.Count > 0 ? DirectionList[0].GroupModel!.ScienceModel!.Name : "???";
            ScienceId = DirectionList.Count > 0 ? DirectionList[0].GroupModel!.ScienceId : 0;
            GroupName = DirectionList.Count > 0 ? DirectionList[0].GroupModel!.Name : "???";
        }
    }
}