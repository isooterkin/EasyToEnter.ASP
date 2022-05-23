using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.ViewsModels.Components;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class VariabilitySelectionContainerViewModel
    {
        public readonly List<VariabilityModel> VariabilityList;
        public readonly List<SelectListItemSubtext> FormSelectListItem;
        public readonly List<SelectListItemSubtext> FormatSelectListItem;
        public readonly List<SelectListItemSubtext> PaymentSelectListItem;
        public readonly List<SelectListItemSubtext> EntranceExamsSelectListItem;
        public readonly List<SelectListItemSubtext> AccreditationSelectListItem;
        public readonly List<SelectListItemSubtext> MilitaryDepartmentSelectListItem;
        public readonly int LevelFocusId;
        public readonly int LevelId;
        public readonly string LevelName;
        public readonly string ScienceName;
        public readonly string GroupName;
        public readonly string DirectionName;
        public readonly int ScienceId;
        public readonly int GroupId;
        public readonly int DirectionId;
        public readonly string FocusName;

        public VariabilitySelectionContainerViewModel(List<VariabilityModel> variabilityList, List<SelectListItemSubtext> formSelectListItem, List<SelectListItemSubtext> formatSelectListItem, List<SelectListItemSubtext> paymentSelectListItem, List<SelectListItemSubtext> entranceExamsSelectListItem, List<SelectListItemSubtext> accreditationSelectListItem, List<SelectListItemSubtext> militaryDepartmentSelectListItem, int levelFocus)
        {
            VariabilityList = variabilityList;
            FormSelectListItem = formSelectListItem;
            FormatSelectListItem = formatSelectListItem;
            PaymentSelectListItem = paymentSelectListItem;
            EntranceExamsSelectListItem = entranceExamsSelectListItem;
            AccreditationSelectListItem = accreditationSelectListItem;
            MilitaryDepartmentSelectListItem = militaryDepartmentSelectListItem;
            LevelFocusId = levelFocus;

            if (VariabilityList.Count > 0)
            {
                ScienceId = VariabilityList[0].FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionModel!.GroupModel!.ScienceId;
                GroupId = VariabilityList[0].FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionModel!.GroupId;
                DirectionId = VariabilityList[0].FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionId;
                LevelId = VariabilityList[0].FocusUniversityModel!.LevelFocusModel!.LevelId;
                LevelName = VariabilityList[0].FocusUniversityModel!.LevelFocusModel!.LevelModel!.Name;
                GroupName = VariabilityList[0].FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionModel!.GroupModel!.Name;
                ScienceName = VariabilityList[0].FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionModel!.GroupModel!.ScienceModel!.Name;
                DirectionName = VariabilityList[0].FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionModel!.Name;
                FocusName = VariabilityList[0].FocusUniversityModel!.LevelFocusModel!.FocusModel!.Name;
            }
            else
            {
                ScienceId = 0;
                GroupId = 0;
                DirectionId = 0;
                LevelId = 0;
                LevelName = "???";
                GroupName = "???";
                ScienceName = "???";
                DirectionName = "???";
                FocusName = "???";
            }
        }
    }
}