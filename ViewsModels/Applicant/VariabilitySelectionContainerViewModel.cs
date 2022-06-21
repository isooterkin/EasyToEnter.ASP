using EasyToEnter.ASP.ViewsModels.Components;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class VariabilitySelectionContainerViewModel
    {
        public readonly List<VariabilityViewModel> VariabilityViewModelList;
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

        public VariabilitySelectionContainerViewModel(List<VariabilityViewModel> variabilityViewModelList, List<SelectListItemSubtext> formSelectListItem, 
            List<SelectListItemSubtext> formatSelectListItem, List<SelectListItemSubtext> paymentSelectListItem, 
            List<SelectListItemSubtext> entranceExamsSelectListItem, List<SelectListItemSubtext> accreditationSelectListItem, 
            List<SelectListItemSubtext> militaryDepartmentSelectListItem, List<SelectListItemSubtext> dormitoryDepartmentSelectListItem,
            List<SelectListItemSubtext> specializationSelectListItem, int levelFocus)
        {
            VariabilityViewModelList = variabilityViewModelList;
            FormSelectListItem = formSelectListItem;
            FormatSelectListItem = formatSelectListItem;
            PaymentSelectListItem = paymentSelectListItem;
            EntranceExamsSelectListItem = entranceExamsSelectListItem;
            AccreditationSelectListItem = accreditationSelectListItem;
            MilitaryDepartmentSelectListItem = militaryDepartmentSelectListItem;
            DormitoryDepartmentSelectListItem = dormitoryDepartmentSelectListItem;
            SpecializationSelectListItem = specializationSelectListItem;
            LevelFocusId = levelFocus;

            if (!VariabilityViewModelList.Any()) return;

            ScienceId = VariabilityViewModelList[0].FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionModel!.GroupModel!.ScienceId;
            GroupId = VariabilityViewModelList[0].FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionModel!.GroupId;
            DirectionId = VariabilityViewModelList[0].FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionId;
            LevelId = VariabilityViewModelList[0].FocusUniversityModel!.LevelFocusModel!.LevelId;
            LevelName = VariabilityViewModelList[0].FocusUniversityModel!.LevelFocusModel!.LevelModel!.Name;
            GroupName = VariabilityViewModelList[0].FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionModel!.GroupModel!.Name;
            ScienceName = VariabilityViewModelList[0].FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionModel!.GroupModel!.ScienceModel!.Name;
            DirectionName = VariabilityViewModelList[0].FocusUniversityModel!.LevelFocusModel!.FocusModel!.DirectionModel!.Name;
            FocusName = VariabilityViewModelList[0].FocusUniversityModel!.LevelFocusModel!.FocusModel!.Name;
        }
    }
}