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
        }
    }
}