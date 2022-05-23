using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.ViewsModels.Components;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class FocusSelectionContainerViewModel
    {
        public readonly List<VariabilityModel> VariabilityList;
        public readonly List<LevelFocusModel> LevelFocusList;
        public readonly List<SelectListItemSubtext> AreaSelectListItem;
        public readonly int LevelId;
        public readonly int DirectionId;
        public readonly string LevelName;
        public readonly string ScienceName;
        public readonly string GroupName;
        public readonly string DirectionName;
        public readonly int ScienceId;
        public readonly int GroupId;

        public FocusSelectionContainerViewModel(List<VariabilityModel> variabilityList, List<LevelFocusModel> levelFocusList, List<SelectListItemSubtext> areaSelectListItem, int level, int direction)
        {
            VariabilityList = variabilityList;
            LevelFocusList = levelFocusList;
            AreaSelectListItem = areaSelectListItem;
            LevelId = level;
            DirectionId = direction;
            LevelName = variabilityList.Count > 0 ? variabilityList[0].FocusUniversityModel!.LevelFocusModel!.LevelModel!.Name : "???";
            ScienceName = LevelFocusList.Count > 0 ? LevelFocusList[0].FocusModel!.DirectionModel!.GroupModel!.ScienceModel!.Name : "???";
            ScienceId = LevelFocusList.Count > 0 ? LevelFocusList[0].FocusModel!.DirectionModel!.GroupModel!.ScienceId : 0;
            GroupName = LevelFocusList.Count > 0 ? LevelFocusList[0].FocusModel!.DirectionModel!.GroupModel!.Name : "???";
            GroupId = LevelFocusList.Count > 0 ? LevelFocusList[0].FocusModel!.DirectionModel!.GroupId : 0;
            DirectionName = LevelFocusList.Count > 0 ? LevelFocusList[0].FocusModel!.DirectionModel!.Name : "???";
        }
    }
}