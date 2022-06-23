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

        // Фильтры Range
        public readonly int MinTrainingPeriod;
        public readonly int MaxTrainingPeriod;
        public readonly int SelectMinTrainingPeriod;
        public readonly int SelectMaxTrainingPeriod;
        public readonly int MinPassingGrade;
        public readonly int MaxPassingGrade;
        public readonly int SelectMinPassingGrade;
        public readonly int SelectMaxPassingGrade;
        public readonly int MinTuition;
        public readonly int MaxTuition;
        public readonly int SelectMinTuition;
        public readonly int SelectMaxTuition;
        public readonly int MinNumberSeats;
        public readonly int MaxNumberSeats;
        public readonly int SelectMinNumberSeats;
        public readonly int SelectMaxNumberSeats;

        public VariabilitySelectionContainerViewModel(List<VariabilityViewModel> variabilityViewModelList, List<SelectListItemSubtext> formSelectListItem, 
            List<SelectListItemSubtext> formatSelectListItem, List<SelectListItemSubtext> paymentSelectListItem, 
            List<SelectListItemSubtext> entranceExamsSelectListItem, List<SelectListItemSubtext> accreditationSelectListItem, 
            List<SelectListItemSubtext> militaryDepartmentSelectListItem, List<SelectListItemSubtext> dormitoryDepartmentSelectListItem,
            List<SelectListItemSubtext> specializationSelectListItem, int levelFocus, int minTrainingPeriod, 
            int maxTrainingPeriod, int selectMinTrainingPeriod, int selectMaxTrainingPeriod,
            int minPassingGrade, int maxPassingGrade, int selectMinPassingGrade, int selectMaxPassingGrade,
            int minTuition, int maxTuition, int selectMinTuition, int selectMaxTuition, int minNumberSeats, 
            int maxNumberSeats, int selectMinNumberSeats, int selectMaxNumberSeats)
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

            MinTrainingPeriod = minTrainingPeriod;
            MaxTrainingPeriod = maxTrainingPeriod;
            SelectMinTrainingPeriod = selectMinTrainingPeriod;
            SelectMaxTrainingPeriod = selectMaxTrainingPeriod;
            MinPassingGrade = minPassingGrade;
            MaxPassingGrade = maxPassingGrade;
            SelectMinPassingGrade = selectMinPassingGrade;
            SelectMaxPassingGrade = selectMaxPassingGrade;
            MinTuition = minTuition;
            MaxTuition = maxTuition;
            SelectMinTuition = selectMinTuition;
            SelectMaxTuition = selectMaxTuition;
            MinNumberSeats = minNumberSeats;
            MaxNumberSeats = maxNumberSeats;
            SelectMinNumberSeats = selectMinNumberSeats;
            SelectMaxNumberSeats = selectMaxNumberSeats;

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