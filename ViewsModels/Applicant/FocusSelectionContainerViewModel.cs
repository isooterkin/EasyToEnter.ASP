using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.ViewsModels.Components;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class FocusSelectionContainerViewModel
    {
        public readonly List<VariabilityModel> VariabilityList;
        public readonly List<LevelFocusModel> LevelFocusList;
        public readonly List<SelectListItemSubtext> AreaSelectListItem;
        public readonly List<SelectListItemSubtext> ProfessionSelectListItem;
        public readonly int LevelId;
        public readonly int DirectionId;
        public readonly string LevelName = string.Empty;
        public readonly string ScienceName = string.Empty;
        public readonly string GroupName = string.Empty;
        public readonly string DirectionName = string.Empty;
        public readonly int ScienceId = 0;
        public readonly int GroupId = 0;

        public FocusSelectionContainerViewModel(List<VariabilityModel> variabilityList, List<LevelFocusModel> levelFocusList, List<SelectListItemSubtext> areaSelectListItem, List<SelectListItemSubtext> professionSelectListItem, int level, int direction)
        {
            VariabilityList = variabilityList;
            LevelFocusList = levelFocusList;
            AreaSelectListItem = areaSelectListItem;
            ProfessionSelectListItem = professionSelectListItem;
            LevelId = level;
            DirectionId = direction;

            if (!VariabilityList.Any()) return;

            LevelName = variabilityList[0].FocusUniversityModel!.LevelFocusModel!.LevelModel!.Name;
            ScienceName = LevelFocusList[0].FocusModel!.DirectionModel!.GroupModel!.ScienceModel!.Name;
            GroupName = LevelFocusList[0].FocusModel!.DirectionModel!.GroupModel!.Name;
            DirectionName = LevelFocusList[0].FocusModel!.DirectionModel!.Name;
            ScienceId = LevelFocusList[0].FocusModel!.DirectionModel!.GroupModel!.ScienceId;
            GroupId = LevelFocusList[0].FocusModel!.DirectionModel!.GroupId;
        }
    }
}