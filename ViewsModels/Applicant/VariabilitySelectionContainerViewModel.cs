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
        public readonly List<SelectListItemSubtext> DormitoryDepartmentSelectListItem;
        public readonly List<SelectListItemSubtext> SpecializationSelectListItem;
        public readonly int LevelFocusId;
        public readonly int LevelId = 0;
        public readonly string LevelName = string.Empty;
        public readonly string ScienceName = string.Empty;
        public readonly string GroupName = string.Empty;
        public readonly string DirectionName = string.Empty;
        public readonly int ScienceId = 0;
        public readonly int GroupId = 0;
        public readonly int DirectionId = 0;
        public readonly string FocusName = string.Empty;

        public VariabilitySelectionContainerViewModel(List<VariabilityModel> variabilityList, List<SelectListItemSubtext> formSelectListItem, 
            List<SelectListItemSubtext> formatSelectListItem, List<SelectListItemSubtext> paymentSelectListItem, 
            List<SelectListItemSubtext> entranceExamsSelectListItem, List<SelectListItemSubtext> accreditationSelectListItem, 
            List<SelectListItemSubtext> militaryDepartmentSelectListItem, List<SelectListItemSubtext> dormitoryDepartmentSelectListItem,
            List<SelectListItemSubtext> specializationSelectListItem, int levelFocus)
        {
            VariabilityList = variabilityList;
            FormSelectListItem = formSelectListItem;
            FormatSelectListItem = formatSelectListItem;
            PaymentSelectListItem = paymentSelectListItem;
            EntranceExamsSelectListItem = entranceExamsSelectListItem;
            AccreditationSelectListItem = accreditationSelectListItem;
            MilitaryDepartmentSelectListItem = militaryDepartmentSelectListItem;
            DormitoryDepartmentSelectListItem = dormitoryDepartmentSelectListItem;
            SpecializationSelectListItem = specializationSelectListItem;
            LevelFocusId = levelFocus;

            if (!VariabilityList.Any()) return;

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
    }
}