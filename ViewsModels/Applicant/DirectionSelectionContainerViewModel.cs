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
            if (variabilityList.Any())
            {
                LevelName = variabilityList[0].FocusUniversityModel!.LevelFocusModel!.LevelModel!.Name;
                ScienceName = DirectionList[0].GroupModel!.ScienceModel!.Name;
                GroupName = DirectionList[0].GroupModel!.Name;
                ScienceId = DirectionList[0].GroupModel!.ScienceId;
            }
            else
            {
                LevelName = "???";
                ScienceName = "???";
                GroupName = "???";
                ScienceId = 0;
            }
        }
    }
}